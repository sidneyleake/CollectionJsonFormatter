using CollectionJsonFormatter.Attributes;
namespace CollectionJsonFormatter.Models
{
    public class LinkProperty
    {
        public string Href { get; set; }

        public string Rel { get; set; }

        public string Name { get; set; }

        public string Render { get; set; }

        public string Prompt { get; set; }
    }
}