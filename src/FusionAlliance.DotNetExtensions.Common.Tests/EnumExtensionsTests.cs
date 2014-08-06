using System;
using System.Linq;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        public enum DummyEnum
        {
            [Foo] [Foo] [Bar] Value1,

            [Foo] [Bar] Value2,

            [Bar] Value3
        }

        [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
        public class FooAttribute : Attribute
        {
        }

        public class BarAttribute : Attribute
        {
        }

        [Test]
        public void GetCustomAttributes_multiple()
        {
            var customAttributes = DummyEnum.Value1.GetCustomAttributes<FooAttribute>();
            Assert.AreEqual(2, customAttributes.Count());
        }

        [Test]
        public void GetCustomAttributes_none()
        {
            var customAttributes = DummyEnum.Value3.GetCustomAttributes<FooAttribute>();
            Assert.IsFalse(customAttributes.Any());
        }

        [Test]
        public void GetCustomAttributes_single()
        {
            var customAttributes = DummyEnum.Value2.GetCustomAttributes<BarAttribute>();
            Assert.AreEqual(1, customAttributes.Count());
        }
    }
}