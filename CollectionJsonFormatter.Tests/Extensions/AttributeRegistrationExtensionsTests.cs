namespace CollectionJsonFormatter.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CollectionJsonFormatter;
    using CollectionJsonFormatter.Attributes;
    using CollectionJsonFormatter.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AttributeRegistrationExtensionsTests
    {
        [TestMethod]
        public void Can_register_add_collection_link_attribute()
        {
            // Arrange
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<AddCollectionLink>(
                new AddCollectionLink("test/href", "test"));
            var registeredAttribute = CollectionJsonConfiguration.GetRegisteredAttributes<AddCollectionLink>(typeof(TestType))
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
            Assert.AreEqual("test/href", registeredAttribute.Href);
            Assert.AreEqual("test", registeredAttribute.Rel);
        }

        [TestMethod]
        public void Can_register_add_href_attribute()
        {
            // Arrange
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<AddHref>(
                new AddHref("test/href"));
            var registeredAttribute = CollectionJsonConfiguration.GetRegisteredAttributes<AddHref>(typeof(TestType))
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
            Assert.AreEqual("test/href", registeredAttribute.Href);
        }

        [TestMethod]
        public void Can_register_add_item_link_attribute()
        {
            // Arrange
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<AddItemLink>(
                new AddItemLink("test/href", "test"),
                "Property1");
            var registeredAttribute = CollectionJsonConfiguration.GetRegisteredAttributes<AddItemLink>(typeof(TestType), "Property1")
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
            Assert.AreEqual("test/href", registeredAttribute.Href);
            Assert.AreEqual("test", registeredAttribute.Rel);
        }

        [TestMethod]
        public void Can_register_add_query_attriute()
        {
            // Arrange
            var type = typeof(TestType);
            
            // Act
            type.RegisterAttribute<AddQuery>(
                new AddQuery("test"));
            var registeredAttribute = CollectionJsonConfiguration.GetRegisteredAttributes<AddQuery>(typeof(TestType))
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
            Assert.AreEqual("test", registeredAttribute.Name);
        }

        [TestMethod]
        public void Can_register_add_template_attribute()
        {
            // Arrage
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<AddTemplate>(new AddTemplate());
            var registeredAttribute = CollectionJsonConfiguration.GetRegisteredAttributes<AddTemplate>(typeof(TestType));

            // Assert
            Assert.IsNotNull(registeredAttribute);
        }

        [TestMethod]
        public void Can_register_collection_json_ignore_attribute()
        {
            // Arrange
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<CollectionJsonIgnore>(
                new CollectionJsonIgnore(),
                "Property1");
            var registeredAttribute = CollectionJsonConfiguration.GetRegisteredAttributes<CollectionJsonIgnore>(typeof(TestType), "Property1")
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
        }

        [TestMethod]
        public void Can_register_collection_json_regex_attribute()
        {
            // Arrange
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<CollectionJsonRegex>(
                new CollectionJsonRegex("test"),
                "Property1");
            var registeredAttribute = CollectionJsonConfiguration
                .GetRegisteredAttributes<CollectionJsonRegex>(typeof(TestType), "Property1")
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
            Assert.AreEqual("test", registeredAttribute.Pattern);
        }

        [TestMethod]
        public void Can_register_collection_json_required_attribute()
        {
            // Arrange
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<CollectionJsonRequired>(
                new CollectionJsonRequired(),
                "Property1");
            var registeredAttribute = CollectionJsonConfiguration
                .GetRegisteredAttributes<CollectionJsonRequired>(typeof(TestType), "Property1")
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
        }

        [TestMethod]
        public void Can_register_collection_json_template_ignore_attribute()
        {
            // Arrange
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<CollectionJsonTemplateIgnore>(
                new CollectionJsonTemplateIgnore(),
                "Property1");
            var registeredAttribute = CollectionJsonConfiguration
                .GetRegisteredAttributes<CollectionJsonTemplateIgnore>(typeof(TestType), "Property1")
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
        }

        [TestMethod]
        public void Can_register_prompt_attribute()
        {
            // Arrange
            var type = typeof(TestType);

            // Act
            type.RegisterAttribute<Prompt>(
                new Prompt("test"),
                "Property1");
            var registeredAttribute = CollectionJsonConfiguration
                .GetRegisteredAttributes<Prompt>(typeof(TestType), "Property1")
                .First();

            // Assert
            Assert.IsNotNull(registeredAttribute);
            Assert.AreEqual("test", registeredAttribute.Text);
        }

        public class TestType
        {
            public string Property1 { get; set; }

            public string Property2 { get; set; }
        }
    }
}