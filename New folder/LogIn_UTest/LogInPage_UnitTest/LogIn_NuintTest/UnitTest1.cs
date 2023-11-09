using LogInPage_UnitTest.Models;
namespace LogIn_NuintTest
{
    public class Tests
    {
        private UserAuth logIn;
        [SetUp]
        public void Setup()
        {
            logIn = new UserAuth();
        }

        [Test]
        public void Test1()
        {
            string emp_id = "1001";
            string password = "123";
            bool expectedResults = true;

            //act
            var returnData = logIn.isAuthentication(emp_id, password);

            //assert
            Assert.AreEqual(expectedResults, returnData);
            Assert.That(returnData, Is.TypeOf<bool>());
            Assert.That(returnData, Is.True);

            //Assert.Pass();
        }
    }
}