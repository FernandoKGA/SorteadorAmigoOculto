using System;
using System.Collections.Generic;
using SorteadorAmigoOculto.Kernel.Model.Entity;
using SorteadorAmigoOculto.Business;
using Xunit;
using Bogus;

namespace SorteadorAmigoOculto.Tests
{
    public class SorteadorBusinessTest
    {
        private readonly SorteadorBusiness _sorteadorBusiness = new SorteadorBusiness();

        [Theory]
        [MemberData(nameof(GetPessoas), parameters: 5)]
        public void SorteioNaoDeixouNinguemTirarSiMesmo(List<Pessoa> pessoas)
        {
            var pessoasSorteadas = _sorteadorBusiness.SortearAmigoOculto(pessoas);
            
            // garantir que nenhuma pessoa se tirou a si mesma
            foreach (KeyValuePair<Pessoa,Pessoa> pair in pessoasSorteadas){
                Assert.NotEqual(pair.Key,pair.Value);
            }
        }

        [Fact]
        public void SorteioNaoAceitaListaNulaDePessoas()
        {
            Assert.Throws<ArgumentNullException>(() => _sorteadorBusiness.SortearAmigoOculto(null));
        }

        [Fact]
        public void SorteioComListaSemNenhumaPessoa()
        {
            var pessoas = GenerateListaSemPessoas();
            var ex = Assert.Throws<InvalidOperationException>(() => _sorteadorBusiness.SortearAmigoOculto(pessoas));
            Assert.True(ex.Message.Equals("The list passed as argument is empty."));
        }

        [Fact]
        public void SorteioComListaDeUmaPessoa()
        {
            var pessoas = GenerateListaComUmaPessoa();
            var ex = Assert.Throws<InvalidOperationException>(() => _sorteadorBusiness.SortearAmigoOculto(pessoas));
            Assert.True(ex.Message.Equals("The list passed has only one person."));
        }

        [Fact]
        public void SorteioComListaDeDuasPessoasComUmaNula()
        {
            var pessoas = GenerateListaComDuasPessoasComUmaNula();
            var ex = Assert.Throws<NullReferenceException>(() => _sorteadorBusiness.SortearAmigoOculto(pessoas));
            Assert.True(ex.Message.Equals("The list has a null object inside of it."));
        }

        [Fact]
        public void SorteioComListaDeDuasPessoasComMesmoEmail()
        {
            var pessoas = GenerateListaComDuasPessoasComMesmoEmail();
            var ex = Assert.Throws<InvalidOperationException>(() => _sorteadorBusiness.SortearAmigoOculto(pessoas));
            Assert.True(ex.Message.Equals("The list contains a duplicated e-mail."));
        }

        public static List<Pessoa> GenerateListaSemPessoas()
        {
            return new List<Pessoa>();
        }

        public static List<Pessoa> GenerateListaComUmaPessoa()
        {
            return new List<Pessoa>
            {
                MethodsForTesting.FakePessoa()
            };
        }

        public static List<Pessoa> GenerateListaComDuasPessoasComUmaNula()
        {
            return new List<Pessoa>
            {
                null,
                MethodsForTesting.FakePessoa()
            };
        }

        public static List<Pessoa> GenerateListaComDuasPessoasComMesmoEmail()
        {
            var pessoa = MethodsForTesting.FakePessoa();
            var pessoa2 = MethodsForTesting.FakePessoa();
            pessoa2.Email = pessoa.Email;
            return new List<Pessoa>
            {
                pessoa,
                pessoa2
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
            var dictio = new Dictionary<string,Pessoa>();
            for(int i=0; i<quantidadePessoas; i++){
                Pessoa pessoa = MethodsForTesting.FakePessoa();
                if(!dictio.ContainsKey(pessoa.Email)) {
                    dictio.Add(pessoa.Email,null);
                    lista.Add(pessoa);
                }
            }

            return MethodsForTesting.ToObjectArray(lista);
        }
    }
}
