namespace CollectionJsonFormatter.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AddHref : CollectionJsonAttribute
    {
        public string Href { get; private set; }

        public AddHref(string href)
        {
            Href = href;
        }
    }
}