namespace CollectionJsonFormatter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class QueryProperty
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Name { get; set; }
        public string Prompt { get; set; }
        public IEnumerable<DataProperty> Data { get; set; }
    }
}
