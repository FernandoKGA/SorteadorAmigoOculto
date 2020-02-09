using System.Collections.Generic;
using SorteadorAmigoOculto.Kernel.Validators;
using Xunit;

namespace SorteadorAmigoOculto.Tests.Validators
{
    public class PessoaValidatorTest
    {
        /*
        Verificacao de emails validos e invalidos,
        segue o topico:
        https://gist.github.com/cjaoude/fd9910626629b53c4d25
        */

        [Fact]
        public void TestaEmailsValidos(){
            //Arrange
            var listaEmailsValidos = GetEmailsValidos();
            var dicionarioEmailsValidos = new Dictionary<string,bool>();

            //Act
            foreach(string email in listaEmailsValidos){
                dicionarioEmailsValidos.Add(email, PessoaValidator.IsEmailValido(email));
            }

            //Assert
            foreach(var parvalor in dicionarioEmailsValidos){
                Assert.True(parvalor.Value,$"Email: {parvalor.Key}");
            }
        }

        private List<string> GetEmailsValidos(){
            return new List<string>{
                "email@example.com",
                "firstname.lastname@example.com",
                "email@subdomain.example.com",
                "firstname+lastname@example.com",
                "email@123.123.123.123",
                "email@[123.123.123.123]",
                '"'+"email"+'"'+"@example.com",
                "1234567890@example.com",
                "email@example-one.com",
                "_______@example.com",
                "email@example.name",
                "email@example.museum",
                "email@example.co.jp",
                "firstname-lastname@example.com"
            };
        }

        private List<string> EmailsValidosEstranhos(){
            return new List<string>{
                @"much.”more\ unusual”@example.com",
                @"very.unusual.”@”.unusual.com@example.com",
                @"very.”(),:;<>[]”.VERY.”very@\\ "+'"'+@"very”.unusual@strange.example.com",
            };
        }

        private List<string> EmailsInvalidos(){
            return new List<string>{
                "plainaddress",
                "#@%^%#$@#$@#.com",
                "@example.com",
                "Joe Smith <email@example.com>",
                "email.example.com",
                "email@example@example.com",
                ".email@example.com",
                "email.@example.com",
                "email..email@example.com",
                "あいうえお@example.com",
                "email@example.com (Joe Smith)",
                "email@example",
                "email@-example.com",
                "email@example.web",
                "email@111.222.333.44444",
                "email@example..com",
                "Abc..123@example.com"
            };
        }

        private List<string> EmailsInvalidosEstranhos(){
            return new List<string>{
                @"”(),:;<>[\]@example.com",
                @"just”not”right@example.com",
                @"this\ is"+'"'+"really"+'"'+@"not\allowed@example.com"
            };
        }
    }
}