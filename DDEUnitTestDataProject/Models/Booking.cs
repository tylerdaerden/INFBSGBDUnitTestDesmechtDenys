using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDEUnitTestDataProject.Models
{
    public class Booking
    {

        //To match Baptiste TestPlan i wrote all of the errormessage in French but choosed to develop/summarize/comment in English to stick to practice i had
        //during my internship

        /// <summary>
        /// Calculates the discount value based on the total price, discount percentage, and promo code validity.
        /// The discount cannot exceed 100% of the total price.
        /// </summary>
        /// <param name="totalPrice">Total price of the order (must be a positive double).</param>
        /// <param name="percentageDiscount">Percentage discount to apply (0 to 100 only).</param>
        /// <param name="isValidPromoCode">Boolean indicating if the promo code is valid.</param>
        /// <returns>The discount value as a double, or throws an exception if inputs are invalid.</returns>
        public static double DiscountValue(object totalPrice, object percentageDiscount, object isValidPromoCode)
        {
            // Validation (params acceptan object so i can check after and not block on params entry in the method)
            if (totalPrice is not double || (double)totalPrice <= 0)
                throw new ArgumentException("Erreur : totalPrice doit être un nombre positif.");
            if (percentageDiscount is not double || (double)percentageDiscount < 0)
                throw new ArgumentException("Erreur : percentageDiscount doit être un nombre positif.");
            if (isValidPromoCode is not bool)
                throw new ArgumentException("Erreur : isValidPromoCode doit être un booléen.");
            double price = (double)totalPrice;
            double discount = (double)percentageDiscount;
            bool isValid = (bool)isValidPromoCode;
            // case of 100% discount 
            if (discount > 100)
            {
                throw new ArgumentException("Erreur : La remise ne peut pas dépasser 100 %.");
            }
            // check of boolean isValid
            if (!isValid)
            {
                return 0.0;
            }
            double discountValue = price * (discount / 100);
            return discountValue;
        }

        /// <summary>
        /// Calculates the total price of all tickets in the order[].
        /// Each ticket price must be a positive double. If any ticket is invalid, an exception is thrown.
        /// </summary>
        /// <param name="ticketPrices">Array of ticket prices.</param>
        /// <returns>Total price as a double, or throws an exception if inputs are invalid.</returns>
        public static double Price(object[] ticketPrices)
        {
            // Validation :check array not empty
            if (ticketPrices == null || ticketPrices.Length == 0)
            {
                throw new ArgumentException("Erreur : La liste des tickets ne peut pas être vide.");
            }
            double totalPrice = 0.0;

            foreach (var ticket in ticketPrices)
            {
                // Validation : check ticket validity
                if (ticket is not double price)
                {
                    throw new ArgumentException("Erreur : Les prix des tickets doivent tous être des nombres.");
                }
                if (price < 0)
                {
                    throw new ArgumentException("Erreur : Le prix d'un ticket ne peut pas être négatif.");
                }
                totalPrice += price;
            }
            return totalPrice;
        }

        /// <summary>
        /// Calculates the final price after applying a discount.
        /// </summary>
        /// <param name="price">The original price (must be a positive double).</param>
        /// <param name="discountValue">The discount value to subtract (must be a positive double).</param>
        /// <returns>The final price after discount, or throws an exception if inputs are invalid.</returns>
        public static double PriceAfterDiscount(object price, object discountValue)
        {
            // Validation (params acceptan object so i can check after and not block on params entry in the method)
            if (price is not double originalPrice)
            {
                throw new ArgumentException("Erreur : price doit être un nombre positif.");
            }
            if (discountValue is not double discount)
            {
                throw new ArgumentException("Erreur : discountValue doit être un nombre positif.");
            }
            // no neg values
            if (originalPrice < 0)
            {
                throw new ArgumentException("Erreur : price ne peut pas être négatif.");
            }
            if (discount < 0)
            {
                throw new ArgumentException("Erreur : discountValue ne peut pas être négatif.");
            }
            double finalPrice = originalPrice - discount;
            if (finalPrice < 0)
            {
                finalPrice = 0.0;
            }
            return finalPrice;
        }
    }
}
