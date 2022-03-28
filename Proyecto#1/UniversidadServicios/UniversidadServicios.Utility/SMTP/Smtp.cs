using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Net;

using System.Text;
using UniversidadServicios.Models.Models;

namespace UniversidadServicios.Utility.SMTP
{
    public class Smtp : ISMTP
    {

        private readonly AppSettings _appSettings;

        public Smtp(AppSettings appSettings) 
        {
          _appSettings = appSettings;
        }

        public void Send(string body, string subject, string destination)
        {
            string emailFrom = _appSettings.EmailFrom;
            string passwordEmail = _appSettings.PasswordEmail;

            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailFrom));
            email.To.Add(MailboxAddress.Parse(destination));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(_appSettings.Host, _appSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailFrom, passwordEmail);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
