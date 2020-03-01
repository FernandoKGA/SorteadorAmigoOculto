using System;
using System.IO;
using SorteadorAmigoOculto.Configuration;
using Xunit;

namespace SorteadorAmigoOculto.Tests.Configuration
{
    public class EmailConfigTest
    {
        [Fact]
        public void TestaEmailCredentials()
        {
            //Arrange
            var config = new EmailConfig();
            var byteArray = new byte[0];

            //Act
            using (FileStream SourceStream = config.GetEmailCredentialsFile())
            {
                byteArray = new byte[SourceStream.Length];
                SourceStream.Read(byteArray, 0, (int)SourceStream.Length);
            }
            var result = System.Text.Encoding.ASCII.GetString(byteArray);

            //Assert
            
        }
    }
}