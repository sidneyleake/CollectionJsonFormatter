namespace CollectionJsonFormatter.Tests.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CollectionJsonFormatter.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HelpersTests
    {
        private string testString = "TestString";
        private string camelCaseString = "testString";
        private string pascalCaseString = "TestString";
        private string lowerCaseString = "teststring";
        private string upperCaseString = "TESTSTRING";
        private string capitalCaseString = "Test String";
        private string hyphenatedString = "Test-String";
        private string hyphenatedLowerCaseString = "test-string";
        private string hyphenatedUpperCaseString = "TEST-STRING";
        private string hyphenatedCapitalCaseString = "Test-String";
        private string sentenceCaseString = "Test string";

        [TestMethod]
        public void Can_format_string_none()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.None);

            // Assert
            Assert.AreEqual(this.testString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_camel_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.CamelCase);

            // Assert
            Assert.AreEqual(this.camelCaseString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_pascal_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.PascalCase);

            // Assert
            Assert.AreEqual(this.pascalCaseString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_lower_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.LowerCase);

            // Assert
            Assert.AreEqual(this.lowerCaseString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_upper_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.UpperCase);

            // Assert
            Assert.AreEqual(this.upperCaseString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_capital_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.CapitalCase);

            // Assert
            Assert.AreEqual(this.capitalCaseString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_hyphenated()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.Hyphenated);

            // Assert
            Assert.AreEqual(this.hyphenatedString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_hyphenated_lower_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.HyphenatedLowerCase);

            // Assert
            Assert.AreEqual(this.hyphenatedLowerCaseString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_hyphenated_upper_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.HyphenatedUpperCase);

            // Assert
            Assert.AreEqual(this.hyphenatedUpperCaseString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_hyphenated_capital_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.HyphenatedCapitalCase);

            // Assert
            Assert.AreEqual(this.hyphenatedCapitalCaseString, formattedString);
        }

        [TestMethod]
        public void Can_format_string_sentence_case()
        {
            // Act
            var formattedString = Helpers.FormatString(this.testString, StringFormat.SentenceCase);

            // Assert
            Assert.AreEqual(this.sentenceCaseString, formattedString);
        }
    }
}
