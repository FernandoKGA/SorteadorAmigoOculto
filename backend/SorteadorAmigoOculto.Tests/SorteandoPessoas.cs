using System.Linq;
using System;
using System.Collections.Generic;
using SorteadorAmigoOculto.Model.Entity;
using SorteadorAmigoOculto.Business;
using Xunit;
using Moq;
using Bogus;

namespace SorteadorAmigoOculto.Tests
{
    public class SorteandoPessoas
    {
        private readonly SorteadorBusiness _sorteadorBusiness = new SorteadorBusiness();

        [Theory]
        [MemberData(nameof(GetPessoas), parameters: 4)]
        public void SorteioNaoDeixouNinguemTirarSiMesmo(List<Pessoa> pessoas)
        {
            var pessoasSorteadas = _sorteadorBusiness.SorteiaAmigoOculto(pessoas);
            
            // garantir que nenhuma pessoa se tirou a si mesma
            foreach (KeyValuePair<Pessoa,Pessoa> pair in pessoasSorteadas){
                Assert.NotEqual(pair.Key,pair.Value);
            }
        }

        [Fact]
        public void SorteioNaoAceitaListaNulaDePessoas()
        {
            Assert.Throws<ArgumentNullException>(() => _sorteadorBusiness.SorteiaAmigoOculto(null));
        }

        [Fact]
        public void SorteioComListaSemNenhumaPessoa()
        {
            var pessoas = GenerateListaSemPessoas();
            var ex = Assert.Throws<InvalidOperationException>(() => _sorteadorBusiness.SorteiaAmigoOculto(pessoas));
            Assert.True(ex.Message.Equals("The list passed as argument is empty."));
        }

        [Fact]
        public void SorteioComListaDeUmaPessoa()
        {
            var pessoas = GenerateListaComUmaPessoa();
            var ex = Assert.Throws<InvalidOperationException>(() => _sorteadorBusiness.SorteiaAmigoOculto(pessoas));
            Assert.True(ex.Message.Equals("The list passed has only one person."));
        }

        [Fact]
        public void SorteioComListaDeDuasPessoasComUmaNula()
        {
            var pessoas = GenerateListaComDuasPessoasComUmaNula();
            var ex = Assert.Throws<NullReferenceException>(() => _sorteadorBusiness.SorteiaAmigoOculto(pessoas));
            Assert.True(ex.Message.Equals("The list has a null object inside of it."));
        }

        public static Pessoa FakePessoa()
        {
            // locales com '_'
            var testPessoa = new Faker<Pessoa>("pt_BR")
                .RuleFor(p => p.Nome, f => f.Name.FullName())
                .RuleFor(p => p.Email, 
                    (f,p) => f.Internet.Email(p.Nome.Split(" ").First(),p.Nome.Split(" ").Last()));

            return testPessoa.Generate();
        }

        public static List<Pessoa> GenerateListaSemPessoas()
        {
            return new List<Pessoa>();
        }

        public static List<Pessoa> GenerateListaComUmaPessoa()
        {
            return new List<Pessoa>
            {
                FakePessoa()
            };
        }

        public static List<Pessoa> GenerateListaComDuasPessoasComUmaNula()
        {
            return new List<Pessoa>
            {
                null,
                FakePessoa()
            };
        }

        public static IEnumerable<object[]> GetPessoas(int numTests)
        {
            if (numTests == 0) throw new ArgumentException("Number of tests has to be greater than or equal to 1.");

            var listas = new List<object[]>();

            for(int i=0; i<numTests; i++){
                listas.Add(GenerateListaComMaisDeDuasPessoas());
            }
            
            return listas;
        }

        public static object[] GenerateListaComMaisDeDuasPessoas()
        {
            var randomizer = new Randomizer();
            int quantidadePessoas = randomizer.Int(2,100);

            var lista = new List<Pessoa>();

            for(int i=0; i<quantidadePessoas; i++){
                lista.Add(FakePessoa());
            }

            return new object[] 
            {
                lista
            };
        }
    }
}
