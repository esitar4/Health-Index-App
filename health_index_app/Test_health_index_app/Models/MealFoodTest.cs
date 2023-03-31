using NUnit.Framework;
using health_index_app.Shared.Models;
using System.Linq;
using static Test_health_index_app.ModelValidator;

namespace Test_health_index_app.Models
{
    public class MealFoodTest
    {
        private MealFood mealfood;

        [SetUp]
        public void Setup()
        {
            mealfood = new MealFood()
            {
                Id = 1,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };
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
            mealfood.Meal.Id = 5;
            mealfood.Food.Id = 0;

            //Act

            //Assert
            Assert.IsTrue(mealfood.Meal.Id == 5);
        }

        [Test]
        public void TestFoodIdSetCorrectly()
        {
            //Arrange
            mealfood.Food.Id = 5;
            mealfood.Meal.Id = 0;
            
            //Act

            //Assert
            Assert.IsTrue(mealfood.Food.Id == 5);
        }

        [Test]
        public void TestServingSizeSetCorrectly()
        {
            //Arrange
            mealfood.Food.Id = 0;
            mealfood.Meal.Id = 0;
            mealfood.Amount = 5.5;

            //Act

            //Assert
            Assert.IsTrue(mealfood.Amount == 5.5);
        }

        [Test]
        [TestCase(1, 1, 10.0)]
        [TestCase(3, 2, 5.0)]
        public void TestValidMealFood(int mealId, int foodId, double amount)
        {
            //Arrange
            mealfood.Meal.Id = mealId;
            mealfood.Food.Id = foodId;
            mealfood.Amount = amount;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(mealfood).Count == 0);
        }

        [Test]
        [TestCase(0, 0, -5.0)]
        [TestCase(0, 0, -0.1)]
        public void TestInValidMealFoodServingSize(int mealId, int foodId, double amount)
        {
            //Arrange
            mealfood.Meal.Id = mealId;
            mealfood.Food.Id = foodId;
            mealfood.Amount = amount;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(mealfood).Count == 1);
            Assert.IsTrue(ValidateModel(mealfood).Any(
                    v => v.MemberNames.Contains("Amount") &&
                         v.ErrorMessage.Contains("Amount must be greater than 0")));
        }

        [Test]
        public void TestDefaultConstructorServingSize()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(mealfood).Count == 0);
            Assert.IsTrue(mealfood.Amount == 1);
        }
    }
}