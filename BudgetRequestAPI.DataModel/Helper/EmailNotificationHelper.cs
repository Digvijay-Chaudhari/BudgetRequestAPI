﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRequestAPI.DataModel.Helper
{
    public class EmailNotificationHelper
    {
        public static string EmailNotification(string fromAddress, string toAddress)
        {
            MailMessage message = new MailMessage("shubhamvijay2022@gmail.com", "digvijay.onkar@euromonitor.com");
            message.Subject = "New request from employee";
            message.Body = "You have a New request for approval";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.UserName = "shubhamvijay2022@gmail.com";
            credential.Password = "utxhzaxdwarcfhkp";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(message);

            return "Success";
        }
    }
}
