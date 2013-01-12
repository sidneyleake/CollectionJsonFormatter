namespace CollectionJsonFormatter.SampleApi.Models
{
    using CollectionJsonFormatter.Attributes;
    
    [AddCollectionLink("/friends/rss", "feed")]
    [AddHref("/friends/{short-name}")]
    [AddItemLink("/blogs/{short-name}", "blog", Prompt = "Blog")]
    [AddItemLink("/images/{short-name}", "avatar", Prompt = "Avatar")]
    [AddQuery("search")]
    [AddTemplate]
    public class AttributedFriend
    {
        private string fullName;

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

        public string ShortName { get; private set; }

        public string Email { get; set; }
    }
}