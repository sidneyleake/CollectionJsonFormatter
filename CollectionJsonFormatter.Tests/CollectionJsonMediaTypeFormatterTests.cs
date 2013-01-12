namespace CollectionJsonFormatter.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CollectionJsonMediaTypeFormatterTests
    {
        [TestMethod]
        public void Can_read_any_type()
        {
            // Arrange
            var formatter = new CollectionJsonMediaTypeFormatter();

            // Act
            var canRead = formatter.CanReadType(typeof(object));

            // Assert
            Assert.IsTrue(canRead);
        }

        [TestMethod]
        public void Can_write_any_type()
        {
            // Arrange
            var formatter = new CollectionJsonMediaTypeFormatter();

            // Act
            var canWrite = formatter.CanWriteType(typeof(object));

            // Assert
            Assert.IsTrue(canWrite);
        }
    }
}
