﻿namespace CollectionJsonFormatter.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AddCollectionLink : CollectionJsonAttribute
    {
        public string Href { get; private set; }

        public string Rel { get; private set; }

        public string Name { get; set; }

        public string Render { get; set; }

        public string Prompt { get; set; }

        public AddCollectionLink(string href, string rel)
        {
            Href = href;
            Rel = rel;
        }
    }
}