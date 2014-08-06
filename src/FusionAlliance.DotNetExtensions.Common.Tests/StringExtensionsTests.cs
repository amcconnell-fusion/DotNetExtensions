using System;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        [TestCase("SGVsbG8sIFdvcmxkIQ==", Result = "Hello, World!")]
        public string Base64Decode_returns_expected_string(string str)
        {
            return str.Base64Decode();
        }

        [Test]
        public void Base64Decode_throws_an_exception_when_string_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => { ((string) null).Base64Decode(); });
        }

        [Test]
        [TestCase("Hello, World!", Result = "SGVsbG8sIFdvcmxkIQ==")]
        [TestCase("This is my secret message", Result = "VGhpcyBpcyBteSBzZWNyZXQgbWVzc2FnZQ==")]
        public string Base64Encode_returns_expected_string(string str)
        {
            return str.Base64Encode();
        }

        [Test]
        public void Base64Encode_throw_an_exception_when_string_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => { ((string) null).Base64Encode(); });
        }

        [Test]
        public void ConvertCamelCaseToPascalCase()
        {
            const string input = "helloWorld";
            const string expected = "HelloWorld";

            var actual = input.ConvertCamelCaseToPascalCase();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConvertPascalCaseToCamelCase()
        {
            const string input = "HelloWorld";
            const string expected = "helloWorld";

            var actual = input.ConvertPascalCaseToCamelCase();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubstringSafe_empty_string()
        {
            var theString = string.Empty;
            var actual = theString.SubstringSafe(4);
            Assert.AreEqual(theString, actual);
        }

        [Test]
        public void SubstringSafe_valid_index()
        {
            const string theString = "hello world";
            var expected = theString.Substring(4);
            var actual = theString.SubstringSafe(4);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof (FormatException))]
        public void ToInt_alpha_string_throws_exception()
        {
            "abc".ToInt();
        }

        [Test]
        public void ToInt_null_string_no_default_returns_null()
        {
            string theString = null;
            var actual = theString.ToInt();
            Assert.IsNull(actual);
        }

        [Test]
        public void ToInt_null_string_with_default_returns_default()
        {
            string theString = null;
            const int expected = 99;
            var actual = theString.ToInt(expected);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToInt_numeric_string()
        {
            var actual = "123".ToInt();
            Assert.AreEqual(123, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_empty_string()
        {
            var phoneString = string.Empty;
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_formats_string()
        {
            const string phoneString = "6536584678";
            const string expected = "653-658-4678";
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_string_contains_alphas()
        {
            const string phoneString = "65C6584A78";
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_string_too_long()
        {
            const string phoneString = "1245658994478";
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_string_too_short()
        {
            const string phoneString = "6584478";
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_empty_string()
        {
            var phoneString = string.Empty;
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_formats_string()
        {
            const string phoneString = "6536584678";
            const string expected = "(653) 658-4678";
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_string_contains_alphas()
        {
            const string phoneString = "65C6584A78";
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_string_too_long()
        {
            const string phoneString = "1245658994478";
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_string_too_short()
        {
            const string phoneString = "6584478";
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(phoneString, actual);
        }
    }
}