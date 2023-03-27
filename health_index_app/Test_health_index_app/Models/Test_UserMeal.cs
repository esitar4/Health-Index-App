using NUnit.Framework;
using health_index_app.Shared.Models;
using System.Linq;
using System;
using static Test_health_index_app.ModelValidator;

namespace Test_health_index_app.Models
{
    public class Test_UserMeal
    {
        private UserMeal userMeal;
        [SetUp]
        public void SetUp()
        {
            userMeal = new UserMeal { Id = 1, UserId = "1", MealId = 1, Name = "chickfila" };           
        }

        [Test]
        public void TestValidUserMeal()
        {
            //Arrange  

            //Act   

            //Assert
            Assert.IsTrue(ValidateModel(userMeal).Count == 0);
        }

        [Test]
        public void TestNameRequired()
        {
            //Arrange  
            userMeal.Name = null;

            //Act   

            //Assert
            Assert.IsTrue(ValidateModel(userMeal).Count == 1);
            Assert.IsTrue(ValidateModel(userMeal).Any(
                v => v.MemberNames.Contains("Name") && 
                     v.ErrorMessage.Contains("Name is a required field")));
            
        }

        [Test]
        public void TestMaxNameLength()
        {
            //Arrange  
            userMeal.Name = "ihatechickfilachickensandwich";

            //Act   

            //Assert
            Assert.IsTrue(ValidateModel(userMeal).Count == 1);
            Assert.IsTrue(ValidateModel(userMeal).Any(
                v => v.MemberNames.Contains("Name") &&
                     v.ErrorMessage.Contains("Name length shouldn't be longer than 15 letters")));

        }
    }
}
