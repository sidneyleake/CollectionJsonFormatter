namespace CollectionJsonFormatter.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CollectionJsonFormatter.Models;
    using CollectionJsonFormatter.Tests.SampleData;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CollectionJsonDocumentTests
    {
        private CollectionJsonDocument collectionJson;
        private string href = "/i/am/a/test";
        private TestMe testModel;

        [TestInitialize]
        public void Initialize()
        {
            this.testModel = new TestMe();
            this.collectionJson = new CollectionJsonDocument(testModel.GetType(), this.href);
        }

        [TestMethod]
        public void Can_add_collection_version()
        {
            // Act
            this.collectionJson.AddCollectionVersion();

            // Assert
            Assert.IsNotNull(collectionJson.Collection.Version);
        }

        [TestMethod]
        public void Can_add_collection_href()
        {
            // Act
            this.collectionJson.AddCollectionHref(this.href);

            // Assert
            Assert.AreEqual(this.href, this.collectionJson.Collection.Href);
        }

        [TestMethod]
        public void Can_add_collection_links()
        {
            // Act
            this.collectionJson.AddCollectionLinks();

            // Assert
            Assert.AreEqual(2, this.collectionJson.Collection.Links.Count());
            Assert.AreEqual(SampleCollectionLinks.LinkOne, this.collectionJson.Collection.Links.First().Href);
        }

        [TestMethod]
        public void Can_add_item()
        {
            // TODO: Implement this test
        }

        [TestMethod]
        public void Can_add_queries()
        {
            // Arrange
            CollectionJsonConfiguration.RegisterQuery("one", new QueryProperty { Name = "one", Href = "/i/am/query/one", Rel = "one" });
            CollectionJsonConfiguration.RegisterQuery("two", new QueryProperty { Name = "two", Href = "/i/am/query/two", Rel = "two" });

            // Act
            this.collectionJson.AddQueries();

            // Assert
            Assert.AreEqual(2, this.collectionJson.Collection.Queries.Count());
        }

        [TestMethod]
        public void Can_add_template()
        {
            // Act
            this.collectionJson.AddTemplate();

            // Assert
            Assert.IsNotNull(this.collectionJson.Collection.Template);
        }
    }
}
