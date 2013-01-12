namespace CollectionJsonFormatter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CollectionProperty
    {
        public string Version { get; set; }
        public string Href { get; set; }
        public IEnumerable<LinkProperty> Links { get; set; }
        public IEnumerable<ItemProperty> Items { get; set; }
        public IEnumerable<QueryProperty> Queries { get; set; }
        public TemplateProperty Template { get; set; }
    }
}
