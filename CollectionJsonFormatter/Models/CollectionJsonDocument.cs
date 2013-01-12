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
            var collectionLinkAttributes = underlyingType
                .GetCustomAttributes(typeof(AddCollectionLink), inherit: false)
                .Cast<AddCollectionLink>();

            var registeredAttributes = CollectionJsonConfiguration
                .GetRegisteredAttributes<AddCollectionLink>(underlyingType);

            collectionLinkAttributes = collectionLinkAttributes.Concat(registeredAttributes);

            var collectionLinks = new List<LinkProperty>();
            foreach (var collectionLinkAttribute in collectionLinkAttributes)
            {
                collectionLinks.Add(new LinkProperty
                {
                    Href = collectionLinkAttribute.Href,
                    Name = collectionLinkAttribute.Name,
                    Prompt = collectionLinkAttribute.Prompt,
                    Rel = collectionLinkAttribute.Rel,
                    Render = collectionLinkAttribute.Render
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
            var queryAttributes = underlyingType
                .GetCustomAttributes(typeof(AddQuery), inherit: false)
                .Cast<AddQuery>();

            var registeredAttributes = CollectionJsonConfiguration
                .GetRegisteredAttributes<AddQuery>(underlyingType);

            queryAttributes = queryAttributes.Concat(registeredAttributes);

            var queries = new List<QueryProperty>();
            foreach (var queryAttribute in queryAttributes)
            {
                queries.Add(CollectionJsonConfiguration.RegisteredQueries[queryAttribute.Name]);
            }

            Collection.Queries = queries;
        }

        public void AddTemplate()
        {
            var hasTemplateAttribute = underlyingType
                .GetCustomAttributes(typeof(AddTemplate), inherit: false)
                .Any();

            if (!hasTemplateAttribute)
            {
                hasTemplateAttribute = CollectionJsonConfiguration.GetRegisteredAttributes<AddTemplate>(underlyingType).Any();
            }

            if (hasTemplateAttribute)
            {
                Collection.Template = TemplateProperty.CreateFrom(underlyingType);
            }
        }
    }
}