using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DDEUnitTestDataProject.Models
{
    public class User
    {
        public static bool CheckEmail(object mailtocheck)
        {
            // type verification
            if (mailtocheck is not string email)
            {
                throw new ArgumentException("Erreur : l'email doit être une chaîne de caractères.");
            }
            var regex = new Regex(@"^(?!.*\.\.)([a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]{1,64})@([a-zA-Z0-9-]{1,63})\.([a-zA-Z]{2,10})$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool CheckName(object name)
        {
            // type and null or white space verification
            if (name is not string nameStr || string.IsNullOrWhiteSpace(nameStr))
            {                
                throw new ArgumentException("Erreur,name doit être une chaîne de caractères non vide.");
            }
            // Vérification de la longueur
            if (nameStr.Length > 50)
            {
                return false;
            }
            var regex = new Regex(@"^([A-ZÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ][a-zàâäéèêëïîôöùûüç]+)([-\s][A-ZÀÂÄÉÈÊËÏÎÔÖÙÛÜÇ][a-zàâäéèêëïîôöùûüç]+)*$");
            if (!regex.IsMatch(nameStr))
            {
                return false;
            }
            return true;
        }

        public static bool CheckPhoneNumber(object phoneNumber)
        {       
            if (phoneNumber is not string number || string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Erreur , phoneNumber doit être une chaîne de caractères (non vide.)");                
            }            
            var regex = new Regex(@"^(\+32|0032|0)?\s?4\d{2}([/\s.-]?\d{2}){3}$");
            if (!regex.IsMatch(number))
            {
                return false;
            }
            return true;
        }


    }
}
