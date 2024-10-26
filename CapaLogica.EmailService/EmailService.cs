using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System;
using System.IO;
using System.Threading;

namespace BimManager.EmailService
{
    public class EmailService
    {
        private static string[] Scopes = { GmailService.Scope.GmailSend };
        private static string ApplicationName = "Tu Aplicación";

        public void SendEmail(string to, string subject, string body, string[] attachments)
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tu Nombre", "tu-email@gmail.com"));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };

            // Agregar archivos adjuntos
            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    if (File.Exists(attachment))
                    {
                        bodyBuilder.Attachments.Add(attachment);
                    }
                }
            }

            message.Body = bodyBuilder.ToMessageBody();

            // Convertir a formato que Gmail puede enviar
            var gmailMessage = new Message
            {
                Raw = Base64UrlEncode(message.ToString())
            };

            service.Users.Messages.Send(gmailMessage, "me").Execute();
        }

        private string Base64UrlEncode(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes)
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", "");
        }
    }
}
