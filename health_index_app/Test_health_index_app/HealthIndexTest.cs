using NUnit.Framework;
using health_index_app.Server.Models;
using System;
using static Test_health_index_app.ModelValidator;
using health_index_app.Shared.Models;
using System.Collections.Generic;
using health_index_app.Shared;

namespace Test_health_index_app
{
    public class HealthIndexTest
    {

        List<Food> foodList;
        [SetUp]
        public void Setup()
        {
            foodList = new List<Food>()
            {
                new Food()
                {
                    Id = 1234,
                    FoodName = "Double-Double Burger",
                    FoodType = "Brand",
                    BrandName = "In-N-Out",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                    ServingId = 1234,
                    ServingDescription = "1 burger",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                    MetricServingAmount = 330,
                    MetricServingUnit = "g",
                    NumberOfUnits = 0,
                    MeasurementDescription = "serving",
                    Calories = 670,
                    CarboHydrate = 39,
                    Protein = 37,
                    Fat = 39,
                    SaturatedFat = 17,
                    PolyunsaturatedFat = 0,
                    Cholesterol = 120,
                    Sodium = 1520,
                    Potassium = 0,
                    Fiber = 3,
                    Sugar = 10,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                },
                new Food
                {
                    Id = 31818,
                    FoodName = "Classic Iceberg Salad",
                    FoodType = "Brand",
                    BrandName = "Dole",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/dole/classic-iceberg-salad",
                    ServingId = 101820,
                    ServingDescription = "1 1/2 cups",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/dole/classic-iceberg-salad",
                    MetricServingAmount = 85,
                    MetricServingUnit = "g",
                    NumberOfUnits = 0,
                    MeasurementDescription = "serving",
                    Calories = 15,
                    CarboHydrate = 4,
                    Protein = 1,
                    Fat = 0,
                    SaturatedFat = 0,
                    PolyunsaturatedFat = 0,
                    Cholesterol = 0,
                    Sodium = 15,
                    Potassium = 0,
                    Fiber = 1,
                    Sugar = 2,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                }
            };
        }


        [Test]
        public void TestValidHealthIndex()
        {
            //Arrange
            double index = 0;

            //Act
            index = HealthIndex.generateHealthIndex(foodList);

            //Assert
            Assert.AreEqual(index, 7.3);
        }

        [Test]
        public void TestInvalidHealthIndex()
        {
            //Arrange
            double index = 0;

            //Act
            index = HealthIndex.generateHealthIndex(foodList);

            //Assert
            Assert.AreNotEqual(index, 10);
        }
    }
}