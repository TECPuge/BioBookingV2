using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BioBookingV2.Utility
{
    public class Mailor
    {
        public void SendMail(string strTo, string strTitle = "Default mailor", string strMessage = "Default mailor message", string strFrom = "TECBioBooking@gmail.com", string strFilePath = null, int intPort = 587, string strHost = "smtp.gmail.com", string strPassword = "DanielLugterAfKarse")
        {
            SmtpClient client = new SmtpClient(strHost, intPort);
            NetworkCredential credentials = new NetworkCredential(strFrom, strPassword);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = credentials;
            client.Send(strFrom, strTo, strTitle, strMessage);
        }
    }
}