namespace CollectionJsonFormatter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CollectionJsonFormatter.Attributes;
    using CollectionJsonFormatter.Common;

    public class TemplateProperty
    {
        public IEnumerable<TemplateDataProperty> Data { get; set; }

        public static TemplateProperty CreateFrom(Type type)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !CollectionJsonConfiguration.AttributeRegistry
                    .Any(ar => ar.PromptFieldName == p.Name && ar.Attribute.GetType() == typeof(CollectionJsonTemplateIgnore)));

            var data = properties.Select(p => new TemplateDataProperty
            {
                Name = Helpers.FormatString(p.Name, CollectionJsonConfiguration.PropertyNameFormat),
                Prompt = GetPrompt(p, type),
                Value = string.Empty,
                Required = GetRequired(p, type),
                Regexp = GetRegex(p, type)
            });

            return new TemplateProperty { Data = data };
        }

        private static string GetPrompt(PropertyInfo info, Type type)
        {
            var promptAttribute = GetPropertyAttribute<Prompt>(info, type);
            var prompt = default(string);
            if (promptAttribute != null)
            {
                prompt = Helpers.FormatString(promptAttribute.Text, CollectionJsonConfiguration.PropertyPromptFormat);
            }
            else if(CollectionJsonConfiguration.UseNameAsDefaultPrompt)
            {
                prompt = Helpers.FormatString(info.Name, CollectionJsonConfiguration.PropertyPromptFormat);
            }

            return prompt;
        }

        private static string GetRequired(PropertyInfo info, Type type)
        {
            var requiredAttribute = GetPropertyAttribute<CollectionJsonRequired>(info, type);

            return requiredAttribute != null ? bool.TrueString.ToLower() : default(string);
        }

        private static string GetRegex(PropertyInfo info, Type type)
        {
            var regexAttribute = GetPropertyAttribute<CollectionJsonRegex>(info, type);

            return regexAttribute != null ? regexAttribute.Pattern : default(string);
        }

        private static T GetPropertyAttribute<T>(PropertyInfo info, Type type)
        {
            return CollectionJsonConfiguration.AttributeRegistry
                .Where(ar => ar.Type == type && ar.PromptFieldName == info.Name && ar.Attribute is T)
                .Select(ar => ar.Attribute)
                .Cast<T>()
                .SingleOrDefault();
        }
    }
}