namespace CollectionJsonFormatter.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CollectionJsonFormatter.Attributes;
    using CollectionJsonFormatter.Models;

    public static class AttributeRegistrationExtensions
    {
        public static Type RegisterAttribute<T>(this Type type, T attribute, string promptFieldName = null)
            where T : Attribute
        {
            var attributeRegistration = new AttributeRegistration { Type = type, Attribute = attribute, PromptFieldName = promptFieldName };
            CollectionJsonConfiguration.AttributeRegistry.Add(attributeRegistration);

            return type;
        }
    }
}