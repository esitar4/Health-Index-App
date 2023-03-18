using NUnit.Framework;
using health_index_app.Server.Models;
using System.Linq;
using System;
using static Test_health_index_app.ModelValidator;

namespace Test_health_index_app.Models
{
    public class Test_ApplicationUser
    {
        private ApplicationUser applicationUser;

        [SetUp]
        public void Setup()
        {
            applicationUser = new ApplicationUser
            {
                Email = "abc@def.com",
                ParentId = "",
                DateOfBirth = DateTime.Now,
                Weight = 100,
                Height = 10,
                Gender = 'M'
            };
        }


        [Test]
        public void TestValidUser()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(applicationUser).Count == 0);
        }

        [Test]
        [TestCase("abcdefg.com")]
        [TestCase("abc@def@")]
        [TestCase("abcd ef")]
        //[TestCase(abc@d ef)] <- Valid
        //[TestCase("abc@def,com")] <- Valid 
        public void TestInvalidEmail(string email)
        {
            //Arrange
            applicationUser.Email = email;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(applicationUser).Count == 1);
            Assert.IsTrue(ValidateModel(applicationUser).Any(
                    v => v.MemberNames.Contains("Email") &&
                         v.ErrorMessage.Contains("Not a valid email address")));

        }

        [Test]
        public void TestEmailRequired()
        {
            //Arrange
            applicationUser.Email = null;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(applicationUser).Count == 1);
            Assert.IsTrue(ValidateModel(applicationUser).Any(
                    v => v.MemberNames.Contains("Email") &&
                         v.ErrorMessage.Contains("required")));

        }

        [Test]
        [TestCase(-1.0)]
        [TestCase(0)]
        [TestCase(10000)]
        public void TestInvalidWeight(double weight)
        {
            //Arrange
            applicationUser.Weight = weight;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(applicationUser).Count == 1);
            Assert.IsTrue(ValidateModel(applicationUser).Any(
                    v => v.MemberNames.Contains("Weight") &&
                         v.ErrorMessage.Contains("Weight must be in between 0 and 9999.99")));

        }

        [Test]
        [TestCase(-1.0)]
        [TestCase(0)]
        [TestCase(1000)]
        public void TestInvalidHeight(double height)
        {
            //Arrange
            applicationUser.Height = height;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(applicationUser).Count == 1);
            Assert.IsTrue(ValidateModel(applicationUser).Any(
                    v => v.MemberNames.Contains("Height") &&
                         v.ErrorMessage.Contains("Height must be in between 0 and less than 999.99")));

        }

        [Test]
        [TestCase('M')]
        [TestCase('F')]
        [TestCase('O')]
        public void TestValidGender(char gender)
        {
            //Arrange
            applicationUser.Gender = gender;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(applicationUser).Count == 0);
            Assert.IsTrue(applicationUser.Gender == gender);

        }

        [Test]
        [TestCase('X')]
        [TestCase('Z')]
        public void TestInvalidGender(char gender)
        {
            //Arrange
            applicationUser.Gender = gender;

            //Act

            //Assert
            Assert.IsTrue(ValidateModel(applicationUser).Count == 1);
            Assert.IsTrue(ValidateModel(applicationUser).Any(
                    v => v.MemberNames.Contains("Gender") &&
                         v.ErrorMessage.Contains("Invalid Gender Character")));

        }
    }
}
