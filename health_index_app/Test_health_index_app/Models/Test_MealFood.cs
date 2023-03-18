using NUnit.Framework;
using health_index_app.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using health_index_app.Shared.Models;
using System.Linq;

namespace Test_health_index_app.Models
{
    public class Test_MealFood
    {
        private MealFood mealfood;

        [SetUp]
        public void Setup()
        {
            mealfood = new MealFood();
        }

        [Test]
        public void TestIdSetCorrectly()
        {
            //Arrange
            mealfood.Id = 5;

            //Act

            //Assert
            Assert.IsTrue(mealfood.Id == 5);
        }

        [Test]
        public void TestMealIdSetCorrectly()
        {
            //Arrange
            mealfood.MealId = 5;
            mealfood.FoodId = 0;

            //Act

            //Assert
            Assert.IsTrue(mealfood.MealId == 5);
        }

        [Test]
        public void TestFoodIdSetCorrectly()
        {
            //Arrange
            mealfood.FoodId = 5;
            mealfood.MealId = 0;
            
            //Act

            //Assert
            Assert.IsTrue(mealfood.FoodId == 5);
        }

        [Test]
        public void TestServingSizeSetCorrectly()
        {
            //Arrange
            mealfood.FoodId = 0;
            mealfood.MealId = 0;
            mealfood.ServingSize = 5.5;

            //Act

            //Assert
            Assert.IsTrue(mealfood.ServingSize == 5.5);
        }

        [Test]
        [TestCase(1, 1, 10.0)]
        [TestCase(3, 2, 5.0)]
        public void TestValidMealFood(int mealId, int foodId, double servingSize)
        {
            //Arrange
            mealfood.MealId = mealId;
            mealfood.FoodId = foodId;
            mealfood.ServingSize = servingSize;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(mealfood).Count == 0);
        }

        [Test]
        [TestCase(0, 0, -5.0)]
        [TestCase(0, 0, -0.1)]
        public void TestInValidMealFoodServingSize(int mealId, int foodId, double servingSize)
        {
            //Arrange
            mealfood.MealId = mealId;
            mealfood.FoodId = foodId;
            mealfood.ServingSize = servingSize;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(mealfood).Count == 1);
            Assert.IsTrue(ValidateModel(mealfood).Any(
                    v => v.MemberNames.Contains("ServingSize") &&
                         v.ErrorMessage.Contains("Serving size must be greater than 0")));
        }

        [Test]
        public void TestDefaultConstructorServingSize()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(mealfood).Count == 0);
            Assert.IsTrue(mealfood.ServingSize == 1);
        }



        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}