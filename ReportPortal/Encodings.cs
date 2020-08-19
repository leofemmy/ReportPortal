using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportPortal
{
    public class Encodings
    {
        static public string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }

        static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);

            string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

            return returnValue;

        }

        static public string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return null;
            var salt = CryptSharp.Crypter.Blowfish.GenerateSalt();
            return CryptSharp.Crypter.Blowfish.Crypt(password, salt);
            //return new NameValue(hashedPassword, salt);
        }

        static public bool CheckPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hashedPassword)) return false;
            return CryptSharp.Crypter.CheckPassword(password, hashedPassword);
        }
    }
}