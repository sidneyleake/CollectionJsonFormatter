namespace CollectionJsonFormatter.Attributes
{
    public class CollectionJsonRegex : CollectionJsonAttribute
    {
        public string Pattern { get; private set; }
        public CollectionJsonRegex(string pattern)
        {
            Pattern = pattern;
        }
    }
}