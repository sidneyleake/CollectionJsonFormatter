namespace CollectionJsonFormatter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TemplateDataProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Prompt { get; set; }
        public string Required { get; set; }
        public string Regexp { get; set; }
    }
}
