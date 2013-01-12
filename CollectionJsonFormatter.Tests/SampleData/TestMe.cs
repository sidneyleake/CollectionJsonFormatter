namespace CollectionJsonFormatter.Tests.SampleData
{
    using CollectionJsonFormatter.Attributes;

    [AddCollectionLink(SampleCollectionLinks.LinkOne, "one")]
    [AddCollectionLink(SampleCollectionLinks.LinkOne, "two")]
    [AddQuery("one")]
    [AddQuery("two")]
    [AddTemplate]
    public class TestMe
    {
        public string PropertyA { get; set; }

        public string PropertyB { get; set; }

        public string PropertyC { get; set; }

        public string PropertyD { get; set; }
    }
}