using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AlmanackAuctionsWebApp.App_Start.Clasess
{
    public class cFunction
    {
        public static string sSecretKey = ConfigurationManager.AppSettings["SecurityKey"];

        public static string Encrypt(String sPlainText)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(sPlainText);

                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                keyArray = hashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(sSecretKey));
                hashMD5.Clear();

                TripleDESCryptoServiceProvider triDESProv = new TripleDESCryptoServiceProvider();
                triDESProv.Key = keyArray;
                triDESProv.Mode = CipherMode.ECB;
                triDESProv.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = triDESProv.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                triDESProv.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string Decrypt(String sCipherText )
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(sCipherText);

                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
                keyArray = hashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(sSecretKey));
                hashMD5.Clear();

                TripleDESCryptoServiceProvider triDESProv = new TripleDESCryptoServiceProvider();
                triDESProv.Key = keyArray;
                triDESProv.Mode = CipherMode.ECB;
                triDESProv.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = triDESProv.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                triDESProv.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}