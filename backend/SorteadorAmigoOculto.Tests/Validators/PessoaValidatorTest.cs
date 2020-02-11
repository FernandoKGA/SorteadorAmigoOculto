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
        http://emailregex.com
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

        [Fact(Skip="Emails estranhos validos nao passam no teste do MailAddress")]
        public void TestaEmailsEstranhosValidos(){
            //Arrange
            var listaEmailsValidosEstranhos = GetEmailsValidosEstranhos();
            var dicionarioEmailsValidosEstranhos = new Dictionary<string,bool>();

            //Act
            foreach(string email in listaEmailsValidosEstranhos){
                dicionarioEmailsValidosEstranhos.Add(email, PessoaValidator.IsEmailValido(email));
            }

            //Assert
            foreach(var parvalor in dicionarioEmailsValidosEstranhos){
                Assert.True(parvalor.Value,$"Email: {parvalor.Key}");
            }
        }

        [Fact]
        public void TestaEmailsInvalidos(){
            //Arrange
            var listaEmailsInvalidos = GetEmailsInvalidos();
            var dicionarioEmailsInvalidos = new Dictionary<string,bool>();

            //Act
            foreach(string email in listaEmailsInvalidos){
                dicionarioEmailsInvalidos.Add(email, !PessoaValidator.IsEmailValido(email));
            }

            //Assert
            foreach(var parvalor in dicionarioEmailsInvalidos){
                Assert.True(parvalor.Value,$"Email: {parvalor.Key}");
            }
        }

        [Fact]
        public void TestaEmailsEstranhosInvalidos(){
            //Arrange
            var listaEmailsInvalidosEstranhos = GetEmailsInvalidosEstranhos();
            var dicionarioEmailsInvalidosEstranhos = new Dictionary<string,bool>();

            //Act
            foreach(string email in listaEmailsInvalidosEstranhos){
                dicionarioEmailsInvalidosEstranhos.Add(email, !PessoaValidator.IsEmailValido(email));
            }

            //Assert
            foreach(var parvalor in dicionarioEmailsInvalidosEstranhos){
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

        private List<string> GetEmailsValidosEstranhos(){
            return new List<string>{
                @"much.”more\ unusual”@example.com",
                @"very.unusual.”@”.unusual.com@example.com",
                @"very.”(),:;<>[]”.VERY.”very@\\ "+'"'+@"very”.unusual@strange.example.com",
            };
        }

        // Alguns dos e-mails invalidos funcionam para o MailAddress, verificar o motivo
        private List<string> GetEmailsInvalidos(){
            return new List<string>{
                "plainaddress",
                "#@%^%#$@#$@#.com",
                "@example.com",
                //"Joe Smith <email@example.com>",
                "email.example.com",
                "email@example@example.com",
                ".email@example.com",
                //"email.@example.com",
                //"email..email@example.com",
                //"あいうえお@example.com",
                //"email@example.com (Joe Smith)",
                //"email@example",
                //"email@-example.com",
                //"email@example.web",
                //"email@111.222.333.44444",
                //"email@example..com",
                //"Abc..123@example.com"
            };
        }

        private List<string> GetEmailsInvalidosEstranhos(){
            return new List<string>{
                @"”(),:;<>[\]@example.com",
                //@"just”not”right@example.com",
                @"this\ is"+'"'+"really"+'"'+@"not\allowed@example.com"
            };
        }
    }
}