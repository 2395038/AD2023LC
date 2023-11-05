using ShoppingCart_UnitTest.Models;
namespace ShoppingCart_NunitTest
{
    public class Tests
    {
        private ShoppingCart sc { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            sc = new ShoppingCart();
        }

        [Test]
        public void getCheckOutTest()
        {
            int q = 2;
            double p = 5.99;
            double expectedTotal = 11.98;

            var total = sc.getCheckOut(q, p);

            Assert.AreEqual(expectedTotal, total);

            Assert.That(total, Is.TypeOf<double>());
        }
    }
}