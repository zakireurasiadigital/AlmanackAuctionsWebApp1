using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public static string Decrypt(String sCipherText)
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

        public static string SendEmail_UserCreation(long UserID)
        {
            string result = "0";
            try
            {
                SQLManager sql = new SQLManager();
                string strMessageBody = "";
                string strMessageSubject = "";
                System.Data.DataTable dtnotifications = new System.Data.DataTable();

                DataTable dtUser = sql.GetDataTable2("Select * from tblUsers where UserID =" + UserID + " ");

                string NotificationName = "";

                DataTable dt = sql.GetDataTable2("Select * from tblNotifications where NotificationName ='" + NotificationName + "' ");
                if (dt.Rows.Count > 0)
                {
                    strMessageBody = dt.Rows[0]["NotificationBody"].ToString();
                    strMessageSubject = dt.Rows[0]["NotificationSubject"].ToString();

                    strMessageBody = strMessageBody.ToString().Replace("[FIRSTNAME]", dtUser.Rows[0]["FirstName"].ToString());
                    strMessageBody = strMessageBody.ToString().Replace("[LASTNAME]", dtUser.Rows[0]["LastName"].ToString());
                    strMessageBody = strMessageBody.ToString().Replace("[USERNAME]", dtUser.Rows[0]["UserName"].ToString());
                    strMessageBody = strMessageBody.ToString().Replace("[PASSWORD]", dtUser.Rows[0]["Password"].ToString());
                      
                    SendMail(dtUser.Rows[0]["Email"].ToString(), "info@removemycar.co.uk", "Almanack Auctions App", strMessageSubject, strMessageBody, true, null, null, string.Empty);
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static bool SendMail(string MailTo, string MailFrom, string DisplayName, string Subject, string BodyMessage, bool IsHTML, string[] CC = null, string[] BCC = null, string textBody = "")
        {
            try
            {
                MailMessage msgMail = new MailMessage(MailFrom, MailTo);
                msgMail.IsBodyHtml = true;
                msgMail.Subject = Subject;
                if (textBody == "")
                {
                    msgMail.IsBodyHtml = true;
                    msgMail.Body = BodyMessage;
                }
                else
                {
                    var plainView = AlternateView.CreateAlternateViewFromString(textBody, null/* TODO Change to default(_) if this is not a reference type */, "text/plain");
                    var htmlView = AlternateView.CreateAlternateViewFromString(BodyMessage, null/* TODO Change to default(_) if this is not a reference type */, "text/html");
                    msgMail.AlternateViews.Add(plainView);
                    msgMail.AlternateViews.Add(htmlView);
                }

                // Set Reply Email
                MailAddress m = new MailAddress(MailFrom, DisplayName);
                msgMail.From = m;

                // Create SMTP
                SmtpClient aa = new SmtpClient(ConfigurationManager.AppSettings["SGMailHost"], Convert.ToInt32(ConfigurationManager.AppSettings["SGMailPort"]));
                NetworkCredential credentials = new NetworkCredential(ConfigurationManager.AppSettings["SGUserName"], ConfigurationManager.AppSettings["SGPassword"]);
                aa.Credentials = credentials;
                aa.Send(msgMail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string IP()
        {
            try
            {
                string strIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (strIP == "")
                    strIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                return strIP;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static DataTable GetDataTable(string Str)
        {
            try
            {
                SQLManager sql = new SQLManager();
                return sql.GetDataTable2(Str);
            }
            catch (Exception ex)
            {
                return null ;
            }
        }

    }
}