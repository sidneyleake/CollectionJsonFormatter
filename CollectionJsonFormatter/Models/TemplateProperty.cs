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
        public IEnumerable<DataProperty> Data { get; set; }

        public static TemplateProperty CreateFrom(Type type)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var data = properties.Select(p => new DataProperty
            {
                Name = Helpers.FormatString(p.Name, CollectionJsonConfiguration.PropertyNameFormat),
                Prompt = GetPrompt(p, type),
                Value = string.Empty
            });

            return new TemplateProperty { Data = data };
        }

        private static string GetPrompt(PropertyInfo info, Type type)
        {
            var prompt = default(string);
            var attribute = info.GetCustomAttribute(typeof(Prompt), inherit: false);
            if (attribute == null)
            {
                attribute = CollectionJsonConfiguration.GetRegisteredAttributes<Prompt>(type, info.Name).SingleOrDefault();
            }

            if (attribute != null)
            {
                var promptAttribute = (Prompt)attribute;
                prompt = Helpers.FormatString(promptAttribute.Text, CollectionJsonConfiguration.PropertyPromptFormat);
            }
            else if (CollectionJsonConfiguration.UseNameAsDefaultPrompt)
            {
                prompt = Helpers.FormatString(info.Name, CollectionJsonConfiguration.PropertyPromptFormat);
            }

            return prompt;
        }
    }
}