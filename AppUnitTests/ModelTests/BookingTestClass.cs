using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUnitTests.ModelTests
{
    public class BookingTestClass
    {
        //Test DiscountValue() with Valid params
        [Theory]
        [InlineData(50.5, 50.0, true, 25.25)]
        [InlineData(22.0, 10.0, true, 2.2)]
        [InlineData(10.0, 100.0, true, 10.0)]
        [InlineData(43.0, 0.0, true, 0.0)]



        public void DiscountValue_ShouldReturnADiscount_WithValidParams(object totalPrice, object percentageDiscount, object isValidPromoCode, double expectedresult)
        {
            //Arrange
            var TotalPriceToTest = totalPrice; var PercentageDiscountToTest = percentageDiscount; var isValidPromoCodeToTest = isValidPromoCode;

            //Act
            var result = DDEUnitTestDataProject.Models.Booking.DiscountValue(TotalPriceToTest, PercentageDiscountToTest, isValidPromoCodeToTest);

            //Assert
            result.Should().BeApproximately(expectedresult, 0.01);
        }

        //Test DiscountValue() with InValid params
        [Theory]
        [InlineData(50.5, 50.0, false, 0.0)]
        [InlineData(43.0, 0.0, false, 0.0)]
        [InlineData(0.0, 20.0, true, 0.0)]

        public void DiscountValue_ShouldReturnZero_WithValidParams(object totalPrice, object percentageDiscount, object isValidPromoCode, double expectedresult)
        {
            //Arrange
            var TotalPriceToTest = totalPrice; var PercentageDiscountToTest = percentageDiscount; var isValidPromoCodeToTest = isValidPromoCode;

            //Act
            var result = DDEUnitTestDataProject.Models.Booking.DiscountValue(TotalPriceToTest, PercentageDiscountToTest, isValidPromoCodeToTest);

            //Assert
            result.Should().BeApproximately(expectedresult, 0.01);
        }

        //Test DiscountValue() with InValid inputs
        [Theory]
        [InlineData("abc", 10.0, true, "Erreur : totalPrice doit être un nombre")]
        [InlineData(50.0, "abc", true, "Erreur : percentageDiscount doit être un nombre")]
        [InlineData(50.0, 10.0, 5, "Erreur : isValidPromoCode doit être un booléen.")]
        [InlineData(-10.0, 15.0, true, "Erreur : totalPrice ne peut pas être négatif.")]
        [InlineData(50.0, -15.0, true, "Erreur : percentageDiscount ne peut pas être négatif.")]
        public void DiscountValue_ShouldReturnException_WithInvalidParams(object totalPrice, object percentageDiscount, object isValidPromoCode, string expectedException)
        {
            //Act
            Action act = () => DDEUnitTestDataProject.Models.Booking.DiscountValue(totalPrice, percentageDiscount, isValidPromoCode);

            //Assert
            act.Should().Throw<ArgumentException>().WithMessage(expectedException);

        }

        //Test Price() with Valid Params
        [Theory]
        [InlineData(new object[] { 10.0 }, 10.0)]
        [InlineData(new object[] { 10.0, 10.0 }, 20.0)]
        [InlineData(new object[] { 10.5, 11.0 }, 21.5)]
        [InlineData(new object[] { 0.0, 0.0, 0.0 }, 0.0)]
        [InlineData(new object[] { 12.0, 10.0, 10.0 }, 32.0)]
        [InlineData(new object[] { 1500.0 }, 1500.0)]
        public void Price_ShouldReturnTotal_WithValidParams(object[] ticketPrices, double expectedTotal)
        {
            // Act - Appel de la méthode avec les tickets
            var result = DDEUnitTestDataProject.Models.Booking.Price(ticketPrices);

            // Assert - Vérification du résultat attendu
            result.Should().BeApproximately(expectedTotal, 0.01);
        }

        //Test Price() With non double params
        [Theory]
        [InlineData(new object[] { "abc" }, "Erreur : Les prix des tickets doivent tous être des nombres.")]
        [InlineData(new object[] { 10.0, "abc" }, "Erreur : Les prix des tickets doivent tous être des nombres.")]
        [InlineData(new object[] { 10.0, 11.0, "abc" }, "Erreur : Les prix des tickets doivent tous être des nombres.")]
        [InlineData(new object[] { 10.0, 11.0, 11.0, "abc" }, "Erreur : Les prix des tickets doivent tous être des nombres.")]
        public void Price_ShouldThrowArgumentException_WhenTicketIsNotANumber(object[] ticketPrices, string expectedException)
        {
            // Act
            Action act = () => DDEUnitTestDataProject.Models.Booking.Price(ticketPrices);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage(expectedException);
        }

        //Test Price() With negatives numbers
        [Fact]
        public void Price_ShouldThrowArgumentException_WhenTicketPriceIsNegative()
        {
            // Arrange
            var ticketPrices = new object[] { -5.0, 10.0, 12.0, 11.5 };

            // Act
            Action act = () => DDEUnitTestDataProject.Models.Booking.Price(ticketPrices);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Erreur : Le prix d'un ticket ne peut pas être négatif.");
        }

        //Test PriceAfterDiscount() with Valid params
        [Theory]
        [InlineData(10.0, 0.0, 10.0)]
        [InlineData(22.0, 2.2, 19.8)]
        [InlineData(50.5, 25.25, 25.25)]
        [InlineData(50.0, 5.0, 45.0)]
        [InlineData(12.0, 20.5, 0.0)]

        public void PriceAfterDiscount_ShouldReturnPrice_WhenParamsAreValid(double price, double discountvalue, double expectedValue)
        {
            //Arrange
            var priceToTest = price; var discountToTest = discountvalue;

            //Act
            var result = DDEUnitTestDataProject.Models.Booking.PriceAfterDiscount(priceToTest, discountToTest);

            //Assert
            result.Should().BeApproximately(expectedValue, 0.01);

        }

        //Test PriceAfterDiscount() with 0 total expected
        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(0.0, 10.0, 0.0)]

        public void PriceAfterDiscount_ShouldReturnZero_WhenParamsAreValid(double price, double discountvalue, double expectedValue)
        {
            //Arrange
            var priceToTest = price; var discountToTest = discountvalue;

            //Act
            var result = DDEUnitTestDataProject.Models.Booking.PriceAfterDiscount(priceToTest, discountToTest);

            //Assert
            result.Should().BeApproximately(expectedValue, 0.01);

        }

        [Theory]
        [InlineData("abc" , 10.0 , "Erreur : price doit être un nombre")]
        [InlineData(22.0 , "abc" , "Erreur : discountValue doit être un nombre")]
        [InlineData(-50.0 , 10.0 , "Erreur : price ne peut pas être négatif")]
        [InlineData(50.0 , -10.0 , "Erreur : discountValue ne peut pas être négatif")]

        public void PriceAfterDiscount_ShouldThrowArgumentException_WhenInvalidInputs(object price , object discountValue , string expectedException)
        {
            //Act
            Action act = () => DDEUnitTestDataProject.Models.Booking.PriceAfterDiscount(price, discountValue);            

            //Assert
            act.Should().Throw<ArgumentException>(expectedException);

        }







    }
}
