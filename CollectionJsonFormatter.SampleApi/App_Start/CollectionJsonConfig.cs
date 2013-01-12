namespace CollectionJsonFormatter.SampleApi
{
    using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CollectionJsonFormatter.Attributes;
using CollectionJsonFormatter.Extensions;
using CollectionJsonFormatter.Models;
using CollectionJsonFormatter.SampleApi.Models;

    public class CollectionJsonConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RegisterAssemblyAttributes();
            RegisterFluidAttributes();
            RegisterQueries();
            config.Formatters.Add(new CollectionJsonMediaTypeFormatter());
        }

        private static void RegisterFluidAttributes()
        {
            var friendType = typeof(FluidFriend);
            friendType
                .RegisterAttribute<AddCollectionLink>(new AddCollectionLink("/friends/rss", "feed"))
                .RegisterAttribute<AddHref>(new AddHref("/friends/{short-name}"))
                .RegisterAttribute<AddItemLink>(new AddItemLink("/friends/blog/{short-name}", "blog") { Prompt = "Blog" })
                .RegisterAttribute<AddItemLink>(new AddItemLink("/friends/images/{short-name}", "avatar") { Prompt = "Avatar" })
                .RegisterAttribute<AddQuery>(new AddQuery("search"))
                .RegisterAttribute<AddTemplate>(new AddTemplate());
        }

        private static void RegisterQueries()
        {
            CollectionJsonConfiguration.RegisterQuery("search", new QueryProperty
            {
                Href = "/friends/search",
                Name = "search",
                Prompt = "Search",
                Rel = "search",
                Data = new List<DataProperty>
                {
                    new DataProperty
                    {
                        Name = "search",
                        Prompt = "Search",
                        Value = string.Empty
                    }
                }
            });
        }

        private static void RegisterAssemblyAttributes()
        {
            var types = Assembly.GetAssembly(typeof(CollectionJsonConfig))
                .GetTypes()
                .Where(t => t.GetCustomAttributes().Any());

            foreach (var type in types)
            {
                var attributes = type.GetCustomAttributes();
                foreach (var attribute in attributes)
                {
                    type.RegisterAttribute(attribute);
                }

                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.GetCustomAttribute<Prompt>() != null);
                foreach (var property in properties)
                {
                    var prompt = property.GetCustomAttribute<Prompt>();
                    type.RegisterAttribute<Prompt>(prompt, property.Name);
                }
            }
        }
    }
}