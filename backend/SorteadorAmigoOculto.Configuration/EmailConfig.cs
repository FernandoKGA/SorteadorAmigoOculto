using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SorteadorAmigoOculto.Configuration
{
    public class EmailConfig
    {
        private readonly FileStream emailCredentials;
        private readonly IConfiguration emailConfig;
        public EmailConfig()
        {
            emailCredentials = new FileStream(Path.Combine(Environment.CurrentDirectory,"EmailConfig/credentials.json"), FileMode.Open, FileAccess.Read);
            emailConfig = new ConfigurationBuilder().AddJsonFile(Path.Combine(Environment.CurrentDirectory,"EmailConfig/emailConfig.json")).Build();
        }

        public string GetEmailFrom()
        {
            return emailConfig.GetSection("emailFrom").Value;   
        }

        public FileStream GetEmailCredentialsFile()
        {
            return emailCredentials;
        }
    }
}