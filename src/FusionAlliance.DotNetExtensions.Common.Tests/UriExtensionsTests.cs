using System;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class UriExtensionsTests
    {
        private const string BaseUri = "http://foo.com/api/bar";
        private const string QueryString = "?baz=123&externalmemberid=1954";

        [Test]
        public void GetBaseUri_with_query()
        {
            var uriWithQuery = new Uri(BaseUri + QueryString);
            var result = uriWithQuery.GetBaseUri();
            Assert.AreEqual(BaseUri, result.AbsoluteUri);
        }

        [Test]
        public void GetBaseUri_without_query()
        {
            var uriWithoutQuery = new Uri(BaseUri);
            var result = uriWithoutQuery.GetBaseUri();
            Assert.AreEqual(BaseUri, result.AbsoluteUri);
        }

        [Test]
        public void GetPathFragment_start_at_final_fragment()
        {
            var uri = new Uri(BaseUri);
            var fragment = uri.GetPathFragment(2);
            Assert.AreEqual("bar", fragment);
        }

        [Test]
        public void GetPathFragment_start_at_middle_fragment()
        {
            var uri = new Uri(BaseUri);
            var fragment = uri.GetPathFragment(1);
            Assert.AreEqual("api/bar", fragment);
        }

        [Test]
        public void QueryWithoutLeadingQuestionMark_with_query()
        {
            var uriWithQuery = new Uri(BaseUri + QueryString);
            var result = uriWithQuery.QueryWithoutLeadingQuestionMark();
            Assert.AreEqual(QueryString.Substring(1), result);
        }

        [Test]
        public void QueryWithoutLeadingQuestionMark_without_query()
        {
            var uriWithQuery = new Uri(BaseUri);
            var result = uriWithQuery.QueryWithoutLeadingQuestionMark();
            Assert.AreEqual(string.Empty, result);
        }
    }
}