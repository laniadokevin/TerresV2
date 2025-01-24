using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Terres.Core.Interfaces;
using Terres.Core.Entities.Generic;

namespace Terres.Data.OLD.Repositories
{
    public class MailService : IMailService
    {
        //Lo comentado son los datos del mail de cresimed
        private const string From = "Cursocresimed@gmail.com";//"sksoft.sendmail@gmail.com"; //"Cursocresimed@gmail.com";
        private const string DisplayName = "Cresimed";
        private const string Password = "hbrfforqwzfyyhso";//"uatbcagvhzlknzyl";//"hbrfforqwzfyyhso";
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;
        private const bool UseSSL = false;
        private const bool UseStartTls = true;

        public async Task<bool> SendAsync(MailData mailData, CancellationToken ct = default)
        {
            try
            {
                var mail = new MimeMessage();

                #region Sender / Receiver

                // Sender
                mail.From.Add(new MailboxAddress(DisplayName, mailData.From ?? From));
                mail.Sender = new MailboxAddress(mailData.DisplayName ?? DisplayName, mailData.From ?? From);

                // Receiver
                mail.To.Add(MailboxAddress.Parse(mailData.To));

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    mail.Bcc.Add(MailboxAddress.Parse(mailData.Bcc));
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    mail.Cc.Add(MailboxAddress.Parse(mailData.Cc));
                }

                #endregion

                #region Content

                // Add Content to Mime Message
                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion

                #region Send Mail

                using var smtp = new SmtpClient();

                if (UseSSL)
                {
                    await smtp.ConnectAsync(Host, Port, SecureSocketOptions.SslOnConnect, ct);
                }
                else if (UseStartTls)
                {
                    await smtp.ConnectAsync(Host, Port, SecureSocketOptions.StartTls, ct);
                }

                await smtp.AuthenticateAsync(From, Password, ct);
                await smtp.SendAsync(mail, ct);
                await smtp.DisconnectAsync(true, ct);

                #endregion

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}