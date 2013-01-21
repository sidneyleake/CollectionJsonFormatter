namespace CollectionJsonFormatter.SampleApi.Models
{
    using CollectionJsonFormatter.Attributes;
using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    
    [AddCollectionLink("/friends/rss", "feed")]
    [AddHref("/friends/{short-name}")]
    [AddItemLink("/blogs/{short-name}", "blog", Prompt = "Blog")]
    [AddItemLink("/images/{short-name}", "avatar", Prompt = "Avatar")]
    [AddQuery("search")]
    [AddTemplate]
    public class AttributedFriend
    {
        private string fullName;

        [CollectionJsonRequired]
        [CollectionJsonRegex("^[a-zA-z]+$")]
        public string FullName
        {
            get { return this.fullName; }
            set
            {
                this.fullName = value;
                var tempName = this.fullName.ToLower();
                ShortName = tempName.Substring(0, 1) + tempName.Substring(tempName.IndexOf(" ") + 1);
            }
        }

        [CollectionJsonTemplateIgnore]
        public string ShortName { get; private set; }

        [CollectionJsonIgnore]
        public string Email { get; set; }
    }
}