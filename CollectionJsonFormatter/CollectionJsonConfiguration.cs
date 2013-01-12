namespace CollectionJsonFormatter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CollectionJsonFormatter.Common;
    using CollectionJsonFormatter.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class CollectionJsonConfiguration
    {
        public JsonSerializerSettings SerializerSettings { get; set; }

        public IContractResolver ContractResolver { get; set; }

        internal static Dictionary<string, QueryProperty> RegisteredQueries { get; set; }

        internal static List<AttributeRegistration> AttributeRegistry { get; set; }

        public static StringFormat PropertyNameFormat = StringFormat.HyphenatedLowerCase;

        public static StringFormat PropertyPromptFormat = StringFormat.CapitalCase;

        public static bool UseNameAsDefaultPrompt = true;

        public CollectionJsonConfiguration()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new LowercaseContractResolver()
            };
        }

        static CollectionJsonConfiguration()
        {
            AttributeRegistry = new List<AttributeRegistration>();
        }

        public static void RegisterQuery(string name, QueryProperty query)
        {
            if (RegisteredQueries == null)
            {
                RegisteredQueries = new Dictionary<string, QueryProperty>();
            }

            if (RegisteredQueries.ContainsKey(name))
            {
                throw new ArgumentException(string.Format("A query already exists with the name: {0}", name));
            }

            RegisteredQueries.Add(name, query);
        }

        public static IEnumerable<T> GetRegisteredAttributes<T>(Type underlyingType, string promptFieldName = null)
        {
            var registeredAttributes = AttributeRegistry.ToLookup(lu => lu.Type)[underlyingType];
            return registeredAttributes
                .Where(ra => ra.PromptFieldName == promptFieldName)
                .Select(ra => ra.Attribute)
                .OfType<T>();
        }
    }
}