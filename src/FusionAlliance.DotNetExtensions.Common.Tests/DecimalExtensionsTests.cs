using System;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class DecimalExtensionsTests
    {
        [Test]
        public void ToInt_truncates_fractional_portion()
        {
            const decimal theDecimal = 123.456m;
            var actual = theDecimal.ToInt();
            Assert.AreEqual(123, actual);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof (OverflowException))]
        public void ToInt_with_large_value_throws_exception()
        {
            decimal.MaxValue.ToInt();
        }

        [Test]
        public void ToLong_truncates_fractional_portion()
        {
            const decimal theDecimal = 123.456m;
            var actual = theDecimal.ToLong();
            Assert.AreEqual(123, actual);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof (OverflowException))]
        public void ToLong_with_large_value_throws_exception()
        {
            decimal.MaxValue.ToLong();
        }
    }
}