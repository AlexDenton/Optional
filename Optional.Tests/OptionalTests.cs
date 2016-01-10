using System;
using NUnit.Framework;

namespace Optional.Tests
{
    [TestFixture]
    public class OptionalTests
    {
        [Test]
        public void WhenOptionalIsSet()
        {
            var optional = new Optional<Int32>(123);

            Assert.IsTrue(optional.IsSet);
            Assert.AreEqual(optional.Value, 123);
        }

        [Test]
        public void WhenOptionalIsNotSet()
        {
            var optional = new Optional<Int32>();

            Assert.IsFalse(optional.IsSet);

            Assert.Throws<NotSetException>(() =>
            {
                var val = optional.Value;
            });
        }
    }
}