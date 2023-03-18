using System;
using System.Linq;
using NUnit.Framework;
using health_index_app.Shared.Models;
using static Test_health_index_app.ModelValidator;

namespace Test_health_index_app.Models
{
    public class Test_Meal
    {
        private Meal meal;

        [SetUp]
        public void Setup()
        {
            meal = new Meal();
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        public void TestIdSetCorrectly(int id)
        {
            //Arrange
            meal.Id = id;

            //Act

            //Assert
            Assert.IsTrue(meal.Id == id);
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(-.5)]
        [TestCase(10.5)]
        public void TestHealthIndexSetCorrectly(double healthIndex)
        {
            //Arrange
            meal.HealthIndex = healthIndex;

            //Act

            //Assert
            Assert.IsTrue(meal.HealthIndex == healthIndex);
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        public void TestValidMeal(double healthIndex)
        {
            //Arrange
            meal.HealthIndex = healthIndex;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(meal).Count == 0);

        }

        [Test]
        [TestCase(-1)]
        [TestCase(11)]
        [TestCase(-.5)]
        [TestCase(10.5)]
        public void TestInvalidHealthIndex(double healthIndex)
        {
            //Arrange
            meal.HealthIndex = healthIndex;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(meal).Count == 1);
            Assert.IsTrue(ValidateModel(meal).Any(
                    v => v.MemberNames.Contains("HealthIndex") &&
                         v.ErrorMessage.Contains("Score must be between 0 and 10")));
        }

        [Test]
        public void TestDefaultConsutructorHealthIndex()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(meal).Count == 1);
            Assert.IsTrue(ValidateModel(meal).Any(
                    v => v.MemberNames.Contains("HealthIndex") &&
                         v.ErrorMessage.Contains("Score must be between 0 and 10")));
        }
    }
}