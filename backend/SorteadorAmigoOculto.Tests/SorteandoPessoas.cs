using System.Collections.Generic;
using SorteadorAmigoOculto.Model.Entity;
using Xunit;
using Moq;

namespace SorteadorAmigoOculto.Tests
{
    public class SorteandoPessoas
    {
        [Theory]
        public void SorteandoPessoasDaLista()
        {
            
        }

        public List<Pessoa> GetPessoas()
        {
            var list = new List<Pessoa>();

            list.AddRange(new List<Pessoa>
            {
                new Pessoa
                {
                    Email = "fake@gmail.com",
                    Nome = "Fake Fake"
                },
                new Pessoa 
                {
                    Email = "idontgetit@hotmail.com",
                    Nome = "I dont get it"
                },
                new Pessoa
                {
                    Email = "teste@gmail.com",
                    Nome = "Teste do teste"
                }
            });

            return list;
        }
    }
}
