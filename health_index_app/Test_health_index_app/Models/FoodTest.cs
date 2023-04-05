using NUnit.Framework;
using health_index_app.Shared.Models;
using System.Linq;
using System;
using static Test_health_index_app.ModelValidator;

namespace Test_health_index_app.Models
{
    public class FoodTest
    {
        private Food food;

        [SetUp]
        public void Setup()
        {
            food = new Food
            {
                Id = 100,
                FoodName = "Big Mac",
                FoodURL = "www.example.com",
                ServingDescription = "lb",
                MetricServingAmount = 100,
                MetricServingUnit = "g",
                MeasurementDescription = "1 lb"
            };
        }


        [Test]
        public void TestValidFood()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(food).Count == 0);
        }

        [Test]
        public void TestFoodNameRequired()
        {
            //Arrange
            food.FoodName = null;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(food).Count == 1);
            Assert.IsTrue(ValidateModel(food).Any(
                    v => v.MemberNames.Contains("FoodName") &&
                         v.ErrorMessage.Contains("required")));

        }

        [Test]
        public void TestFoodURLRequired()
        {
            //Arrange
            food.FoodURL = null;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(food).Count == 1);
            Assert.IsTrue(ValidateModel(food).Any(
                    v => v.MemberNames.Contains("FoodURL") &&
                         v.ErrorMessage.Contains("required")));

        }

        [Test]
        public void TestServingDescriptionRequired()
        {
            //Arrange
            food.ServingDescription = null;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(food).Count == 1);
            Assert.IsTrue(ValidateModel(food).Any(
                    v => v.MemberNames.Contains("ServingDescription") &&
                         v.ErrorMessage.Contains("required")));

        }

        [Test]
        [TestCase(-1)]
        [TestCase(-0.5)]
        public void TestMetricServingAmountRange(double metricServingAmount)
        {
            //Arrange
            food.MetricServingAmount = metricServingAmount;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(food).Count == 1);
            Assert.IsTrue(ValidateModel(food).Any(
                    v => v.MemberNames.Contains("MetricServingAmount") &&
                         v.ErrorMessage.Contains("Metric Serving Amount must be larger than 0")));

        }

        [Test]
        public void TestMeasurementDescriptionRequired()
        {
            //Arrange
            food.MeasurementDescription = null;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(food).Count == 1);
            Assert.IsTrue(ValidateModel(food).Any(
                    v => v.MemberNames.Contains("MeasurementDescription") &&
                         v.ErrorMessage.Contains("required")));

        }
    }
}
