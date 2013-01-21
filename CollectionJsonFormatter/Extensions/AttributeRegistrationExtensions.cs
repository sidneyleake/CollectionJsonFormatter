namespace CollectionJsonFormatter.Extensions
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CollectionJsonFormatter.Attributes;
using CollectionJsonFormatter.Models;
using Newtonsoft.Json;

    public static class AttributeRegistrationExtensions
    {
        public static Type RegisterAttribute<T>(this Type type, T attribute, string promptFieldName = null)
            where T : Attribute
        {
            var attributeRegistration = new AttributeRegistration { Type = type, Attribute = attribute, PromptFieldName = promptFieldName };
            CollectionJsonConfiguration.AttributeRegistry.Add(attributeRegistration);

            return type;
        }

        public static Type Ignore(this Type type, string fieldName)
        {
            var attributeRegistration = new AttributeRegistration { Type = type, Attribute = new CollectionJsonAttribute(), PromptFieldName = fieldName };
            CollectionJsonConfiguration.AttributeRegistry.Add(attributeRegistration);

            return type;
        }

        public static Type TemplateIgnore(this Type type, string fieldName)
        {
            var attributeRegistration = new AttributeRegistration{ Type = type, Attribute = new CollectionJsonTemplateIgnore(), PromptFieldName = fieldName};
            CollectionJsonConfiguration.AttributeRegistry.Add(attributeRegistration);

            return type;
        }

        public static Type CompleteIgnore(this Type type, string fieldName)
        {
            var attributeRegistration = new AttributeRegistration { Type = type, Attribute = new CollectionJsonAttribute(), PromptFieldName = fieldName };
            CollectionJsonConfiguration.AttributeRegistry.Add(attributeRegistration);

            attributeRegistration = new AttributeRegistration { Type = type, Attribute = new CollectionJsonTemplateIgnore(), PromptFieldName = fieldName };
            CollectionJsonConfiguration.AttributeRegistry.Add(attributeRegistration);

            return type;
        }

        public static Type Require(this Type type, string fieldName)
        {
            var attributeRegistration = new AttributeRegistration { Type = type, Attribute = new CollectionJsonRequired(), PromptFieldName = fieldName };
            CollectionJsonConfiguration.AttributeRegistry.Add(attributeRegistration);

            return type;
        }

        public static Type Regex(this Type type, string fieldName, string pattern)
        {
            var attributeRegistration = new AttributeRegistration
            {
                Type = type,
                Attribute = new CollectionJsonRegex(pattern),
                PromptFieldName = fieldName
            };

            CollectionJsonConfiguration.AttributeRegistry.Add(attributeRegistration);

            return type;
        }
    }
}