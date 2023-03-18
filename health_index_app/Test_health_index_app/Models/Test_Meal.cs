using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using health_index_app.Shared.Models;

namespace Test_health_index_app
{
    public class Test_Meal
    {
        private Meal meal;

        [SetUp]
        public void Setup()
        {
            meal = new Meal
            {
            };
        }

        [Test]
        public void ValidMeal()
        {
            //Arrange
            //Act
            //Assert

            Console.WriteLine(ValidateModel(meal).Count);

            foreach (var x in ValidateModel(meal))
            {
                Console.WriteLine(x);
                foreach (var v in x.MemberNames)
                    Console.WriteLine(v);
            }
            Console.WriteLine("Lol");
            Assert.IsTrue(ValidateModel(meal).Any(
                v => v.MemberNames.Contains("Email") &&
                     v.ErrorMessage.Contains("required")));
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