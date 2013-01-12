namespace CollectionJsonFormatter.Models
{
    using System;

    public class AttributeRegistration
    {
        public Type Type { get; set; }

        public Attribute Attribute { get; set; }

        public string PromptFieldName { get; set; }
    }
}