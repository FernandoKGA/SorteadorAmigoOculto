using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using SorteadorAmigoOculto.Interfaces.Business;
using SorteadorAmigoOculto.Kernel.Helpers;
using SorteadorAmigoOculto.Kernel.Model.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SorteadorAmigoOculto.Business
{
    public class GmailBusiness : IEmailBusiness
    {
        public void EnviaSorteio(SorteioDTO sorteioDTO){
            var service = CreateGmailService();

            foreach (KeyValuePair<PessoaDTO,PessoaDTO> pessoas in sorteioDTO.PessoasSorteadas)
            {
                var mailMessage = EmailHelper.CriarMensagem("sorteadoramigooculto@gmail.com", pessoas,sorteioDTO.IdentificadorSorteio);
                
                var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mailMessage);

                var gmailMessage = new Google.Apis.Gmail.v1.Data.Message {
                    Raw = Encode(mimeMessage.ToString())
                };

                Google.Apis.Gmail.v1.UsersResource.MessagesResource.SendRequest request = service.Users.Messages.Send(gmailMessage, "me");

                request.Execute();
            }
        }
        private string Encode(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

            return System.Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        private GmailService CreateGmailService()
        {
            string[] Scopes = { GmailService.Scope.GmailSend };
            string ApplicationName = "Gmail API .NET SorteadorAmigoOculto";

            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            
            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
    }
}