namespace CollectionJsonFormatter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using CollectionJsonFormatter.Attributes;
    using CollectionJsonFormatter.Common;

    public class ItemProperty
    {
        public string Href { get; set; }
        public IEnumerable<DataProperty> Data { get; set; }
        public IEnumerable<LinkProperty> Links { get; set; }

        public static ItemProperty CreateFrom<T>(T entity)
        {
            var itemProperty = new ItemProperty();
            itemProperty.AddHref(entity);
            itemProperty.AddLinks(entity);
            itemProperty.AddData(entity);

            return itemProperty;
        }

        public void AddHref<T>(T entity)
        {
            var type = entity.GetType();
            var hrefAttribute = type
                .GetCustomAttributes(typeof(AddHref), inherit: false)
                .Cast<AddHref>()
                .SingleOrDefault();

            if (hrefAttribute != null)
            {
                Href = Helpers.ResolveTokens<T>(hrefAttribute.Href, entity);
            }
        }

        public void AddLinks<T>(T entity)
        {
            var type = entity.GetType();
            var addLinkAttributes = type.GetCustomAttributes(typeof(AddItemLink), inherit: false).Cast<AddItemLink>();
            Links = addLinkAttributes.Select(ala => new LinkProperty
            {
                Href = Helpers.ResolveTokens(ala.Href, entity),
                Name = Helpers.FormatString(ala.Name, CollectionJsonConfiguration.PropertyNameFormat),
                Prompt = Helpers.FormatString(ala.Prompt, CollectionJsonConfiguration.PropertyPromptFormat),
                Rel = ala.Rel,
                Render = ala.Render
            });
        }

        public void AddData<T>(T entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var value = default(object);

            Data = properties.Select(p => new DataProperty
            {
                Name = Helpers.FormatString(p.Name, CollectionJsonConfiguration.PropertyNameFormat),
                Prompt = GetPrompt(p),
                Value = (value = p.GetValue(entity)) != null ? value.ToString() : null 
            });
        }

        private static string GetPrompt(PropertyInfo info)
        {
            var prompt = default(string);
            var attribute = info.GetCustomAttribute(typeof(Prompt), inherit: false);
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
