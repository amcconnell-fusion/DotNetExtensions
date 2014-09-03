using System;
using System.Diagnostics;
using System.Xml.Linq;
using FusionAlliance.DotNetExtensions.Common.Xml;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests.Xml
{
    [TestFixture]
    public class XmlExtensionsTests
    {
        public class DemoObject
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

        [Test]
        public void ToXml_can_convert_an_object_to_valid_xml()
        {
            var obj = new DemoObject {Name = "John Doe", Age = 99};
            var xml = obj.ToXml().ToString(SaveOptions.DisableFormatting);
            Trace.WriteLine(xml);
            const string expected =
                "<DemoObject xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Name>John Doe</Name><Age>99</Age></DemoObject>";
            Assert.AreEqual(expected, xml);
        }

        [Test]
        public void ToXml_throws_an_exception_when_the_source_object_is_null()
        {
            DemoObject obj = null;

            // ReSharper disable ExpressionIsAlwaysNull - Required by test
            Assert.Throws<ArgumentNullException>(() => obj.ToXml());
        }
    }
}