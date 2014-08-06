using System;
using FusionAlliance.DotNetExtensions.Common.Xml;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests.Xml
{
    [TestFixture]
    public class XmlUtilTests
    {
        public class DemoObject
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

        [Test]
        public void XmlToObject_can_convert_a_string_into_an_object()
        {
            var obj = XmlUtil.XmlToObject<DemoObject>("<DemoObject><Name>John Doe</Name><Age>99</Age></DemoObject>");
            Assert.AreEqual("John Doe", obj.Name);
            Assert.AreEqual(99, obj.Age);
        }

        [Test]
        public void XmlToObject_throws_an_argument_null_exception_when_the_string_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => { XmlUtil.XmlToObject<DemoObject>((string) null); });
        }
    }
}