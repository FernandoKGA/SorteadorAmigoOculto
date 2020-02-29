using System;
using System.Collections.Generic;
using SorteadorAmigoOculto.Kernel.Helpers;
using SorteadorAmigoOculto.Kernel.Model.DTO;
using Xunit;

namespace SorteadorAmigoOculto.Tests.Helpers
{
    public class EmailHelperTest
    {
        [Fact]
        public void TestaCriarMensagem()
        {
            //Arrange
            string from = "sorteadoramigoocult@gmail.com";
            KeyValuePair<PessoaDTO,PessoaDTO> pessoas = new KeyValuePair<PessoaDTO, PessoaDTO>(
                new PessoaDTO{Email = "zueira@gmail.com", Nome = "Auehaeuh"}, 
                new PessoaDTO{Email = "kkkkkk@gmail.com", Nome = "Haskev"}
            );
            Guid guid = new Guid();

            //Act
            var mail = EmailHelper.CriarMensagem(from, pessoas, guid);

            //Assert
            Assert.Contains("Haskev",mail.Body);
            Assert.Contains("kkkkkk@gmail.com",mail.Body);
            Assert.Contains(guid.ToString(),mail.Body);
        }
    }
}