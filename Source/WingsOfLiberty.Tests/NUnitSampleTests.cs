using NUnit.Framework;

namespace WingsOfLiberty.Tests {
    [TestFixture]
    public class NUnitSampleTests : TestBase {
        [Test]
        public void SomePassingTest() {
            Assert.AreEqual(5, 5);
        }

        [Test]
        public void SomeFailingTest() {
            Assert.Greater(5, 7);
        }
    }
}
