namespace CollectionJsonFormatter
{
    using System;
    using System.Collections.Generic;
    using CollectionJsonFormatter.Common;
    using CollectionJsonFormatter.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class CollectionJsonConfiguration
    {
        public JsonSerializerSettings SerializerSettings { get; set; }

        public IContractResolver ContractResolver { get; set; }

        internal static Dictionary<string, QueryProperty> RegisteredQueries { get; set; }

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
    }
}