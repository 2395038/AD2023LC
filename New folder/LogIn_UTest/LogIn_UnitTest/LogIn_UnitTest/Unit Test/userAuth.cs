using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogIn_UnitTest.Modles;
using NUnit.Framework;

namespace LogIn_UnitTest.Unit_Test
{
    public class userAuth
    {

        // private UserAuthentication logIn = new UserAuthentication();
        private UserAuthentication logIn;
        [SetUp]// linking to the class which is going to test

        public void SetUp()
        {
            // we can keep it open if we already initialized the class attribute
            logIn = new UserAuthentication();
            
        }
        [Test] // Test Property of the Unit Test
        // this is the entrypoint for the test methos..for each test method 
        //individual test entry 
        public void TestAuthTest()
        {
            /*
             * inside any test method, we perfrom three operations
             * A- assign : intialize the variables
             * A- act : invoke the method to test
             * A assertion  : check the input and probable return of the method 
             * 
             * so combindly, it's AAA
             */

            //Assign
            string emp_id = "1001";
            string password = "123";
            bool expectedResults = true;

            //act
            var returnData= logIn.isAuthentication(emp_id, password);
            
            //assert
            Assert.AreEqual(expectedResults, returnData);
            Assert.That(returnData, Is.TypeOf<bool>());
            Assert.That(returnData, Is.True);


        }


    }
}
