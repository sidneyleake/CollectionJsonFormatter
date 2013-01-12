namespace CollectionJsonFormatter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CollectionJsonFormatter.Attributes;

    public class CollectionJsonDocument
    {
        private readonly Type underlyingType;

        private readonly string href;

        public CollectionProperty Collection { get; set; }

        public CollectionJsonDocument(Type underlyingType, string href)
        {
            this.underlyingType = underlyingType;
            this.href = href;
            Collection = new CollectionProperty();
        }

        public void Initialize()
        {
            AddCollectionVersion();
            AddCollectionHref(this.href);
            AddCollectionLinks();
            AddQueries();
            AddTemplate();
        }

        public void AddCollectionVersion()
        {
            Collection.Version = "1.0";
        }

        public void AddCollectionHref(string href)
        {
            Collection.Href = href;
        }

        public void AddCollectionLinks()
        {
            var registeredAttributes = CollectionJsonConfiguration
                .GetRegisteredAttributes<AddCollectionLink>(underlyingType);

            var collectionLinks = new List<LinkProperty>();
            foreach (var attribute in registeredAttributes)
            {
                collectionLinks.Add(new LinkProperty
                {
                    Href = attribute.Href,
                    Name = attribute.Name,
                    Prompt = attribute.Prompt,
                    Rel = attribute.Rel,
                    Render = attribute.Render
                });
            }

            Collection.Links = collectionLinks;
        }

        public void AddItem<T>(T entity)
        {
            var item = ItemProperty.CreateFrom(entity);
            var itemList = Collection.Items ?? new List<ItemProperty>();
            Collection.Items = itemList.Concat(new List<ItemProperty> { item });
        }

        public void AddQueries()
        {
            var registeredAttributes = CollectionJsonConfiguration
                .GetRegisteredAttributes<AddQuery>(underlyingType);

            var queries = new List<QueryProperty>();
            foreach (var queryAttribute in registeredAttributes)
            {
                queries.Add(CollectionJsonConfiguration.RegisteredQueries[queryAttribute.Name]);
            }

            Collection.Queries = queries;
        }

        public void AddTemplate()
        {
            var hasTemplateAttribute = CollectionJsonConfiguration.GetRegisteredAttributes<AddTemplate>(underlyingType).Any();

            if (hasTemplateAttribute)
            {
                Collection.Template = TemplateProperty.CreateFrom(underlyingType);
            }
        }
    }
}