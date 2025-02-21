using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using DDEUnitTestDataProject.Models;

namespace AppUnitTests.ModelTests
{
    public class UserTestClass
    {
        //Tests CheckEmail() With Valid Emails
        [Theory]
        [InlineData("test@mail.com")]
        [InlineData("test.adresse@mail.com")]
        [InlineData("TestAdresse@MAIL.com")]
        [InlineData("test@adresse.mail.com")]
        [InlineData("alb#c$d%e&f*g+h=i_j@mail.com")]

        public void CheckEmail_ShouldReturnTrue_WhenEmailIsValid(string email)
        {
            //Arrange
            var emailToTest = email;

            //Act
            var result = DDEUnitTestDataProject.Models.User.CheckEmail(emailToTest);

            //Assert
            result.Should().BeTrue();

        }


        //Test CheckEmail() With Invalid Email
        [Theory]
        [InlineData("@test@mail.com")]
        [InlineData("test@@mail.com")]
        [InlineData("test@mail..com")]
        [InlineData("@mail.com")]
        [InlineData("test.com")]
        [InlineData("test@.com")]
        [InlineData("test..adresse@mail.com")]
        [InlineData("test@alb#c$d%e&f*g+h-i_j.com")]

        public void CheckEmail_ShouldReturnFalse_WhenEmailIsInvalid(string email)
        {
            // Arrange
            var emailToTest = email;

            // Act
            var result = DDEUnitTestDataProject.Models.User.CheckEmail(emailToTest);

            // Assert
            result.Should().BeFalse();
        }

        // Tests CheckEmail() of exceptions , bad type/input
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(2.5)]
        [InlineData(null)]
        public void CheckEmail_ShouldThrowArgumentException_WhenInputIsNotString(object invalidInput)
        {
            // Act
            Action act = () => DDEUnitTestDataProject.Models.User.CheckEmail(invalidInput);

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("Erreur : l'email doit être une chaîne de caractères.");
        }

        //Test CheckName() with valid Name
        [Theory]
        [InlineData("Pierre")]
        [InlineData("Pierre-Olivier")]
        [InlineData("Pierre Olivier")]
        [InlineData("André")]

        public void CheckName_ShouldReturnTrue_WhenNameIsValid(string name)
        {
            //Arrange
            var nameToTest = name;


            //Act
            var result = DDEUnitTestDataProject.Models.User.CheckName(nameToTest);

            //Assert
            result.Should().BeTrue();
        }

        //Test CheckName() with invalid Name
        [Theory]
        [InlineData("-Pierre")]
        [InlineData("Pierre2")]
        [InlineData("pierre")]
        [InlineData("pIERRE")]
        [InlineData("PIErre")]
        [InlineData("Pierre--Olivier")]
        [InlineData("PIerre")]

        public void CheckName_ShouldReturnFalse_WhenNameIsInValid(string name)
        {
            //Arrange
            var nameToTest = name;

            //Act
            var result = DDEUnitTestDataProject.Models.User.CheckName(nameToTest);

            //Assert
            result.Should().BeFalse();

        }

        //Test CheckName() with invalid input
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(2.5)]

        public void CheckName_ShouldThrowArgumentException_WhenInputIsNotAString(object invalidInput)
        {

            //Act
            Action act = () => DDEUnitTestDataProject.Models.User.CheckName(invalidInput);

            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("Erreur,name doit être une chaîne de caractères non vide.");
        }


        //Test CheckPhoneNumber with valid PhoneNumbers
        [Theory]
        [InlineData("+32 475 12 34 56")]
        [InlineData("0475 12 34 56")]
        [InlineData("0032 475 12 34 56")]
        [InlineData("0475/12.34.56")]
        [InlineData("0475123456")]
        [InlineData("0475-12-34-56")]
        [InlineData("0475/12/34/56")]

        public void CheckPhone_ShouldReturnTrue_WithValidPhoneNumbers(string phoneNumbers)
        {
            //Arrange
            var phoneNumbersToTest = phoneNumbers;

            //Act
            var result = DDEUnitTestDataProject.Models.User.CheckPhoneNumber(phoneNumbersToTest);

            //Assert
            result.Should().BeTrue();

        }

        //Test CheckPhoneNumber with Invalid PhoneNumbers
        [Theory]
        [InlineData("0475 12 34 5")]
        [InlineData("0475 12 34 56 7")]
        [InlineData("/0475123456")]
        [InlineData("04751234ab")]
        public void CheckPhone_ShoudReturnFalse_WithInValidPhoneNumbers(string phoneNumbers)
        {
            //Arrange
            var phoneNumbersToTest = phoneNumbers;

            //Act
            var result = DDEUnitTestDataProject.Models.User.CheckPhoneNumber(phoneNumbersToTest);

            //Assert
            result.Should().BeFalse();

        }

        //Test CheckPhoneNumber with Invalid inputs
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(2.5)]
        public void CheckPhoneNumber_ShouldThrowArgumentException_WhenInputIsNotAString(object invalidInput)
        {
            //Act
            Action act = () => DDEUnitTestDataProject.Models.User.CheckPhoneNumber(invalidInput);

            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("Erreur , phoneNumber doit être une chaîne de caractères (non vide.)");
        }






    }

}

