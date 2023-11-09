using LogIn_NunitTest.Models;
namespace ShoppingCart_NunitTest
{
    public class Tests
    {
        private LogIn sc { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            sc = new LogIn();
        }

        [Test]
        public void getLogIn()
        {
            string employeeId = "1001";
            string password = "123";

            var logIn = sc.getLogIn(employeeId,p);

            Assert.AreEqual(expectedTotal, total);

            Assert.That(total, Is.TypeOf<double>());
        }
    }
}