using Bogus;
using SorteadorAmigoOculto.Kernel.Model.DTO;
using SorteadorAmigoOculto.Kernel.Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SorteadorAmigoOculto.Tests
{
    public static class MethodsForTesting
    {
        public static Pessoa FakePessoa()
        {
            // locales com '_'
            var testPessoa = new Faker<Pessoa>("pt_BR")
                .RuleFor(p => p.Nome, f => f.Name.FullName())
                .RuleFor(p => p.Email, 
                    (f,p) => f.Internet.Email(p.Nome.Split(" ").First(),p.Nome.Split(" ").Last()));

            return testPessoa.Generate();
        }

        public static PessoaDTO FakePessoaDTO(){
            // locales com '_'
            var testPessoa = new Faker<PessoaDTO>("pt_BR")
                .RuleFor(p => p.Nome, f => f.Name.FullName())
                .RuleFor(p => p.Email, 
                    (f,p) => f.Internet.Email(p.Nome.Split(" ").First(),p.Nome.Split(" ").Last()));

            return testPessoa.Generate();
        }

        public static object[] ToObjectArray<T>(T obj){
            return new object[]{
                obj
            };
        }

        public static Dictionary<Pessoa,Pessoa> GenerateDicionarioPessoas(){
            return new Dictionary<Pessoa, Pessoa>{
                { MethodsForTesting.FakePessoa(), MethodsForTesting.FakePessoa() },
                { MethodsForTesting.FakePessoa(), MethodsForTesting.FakePessoa() },
                { MethodsForTesting.FakePessoa(), MethodsForTesting.FakePessoa() },
                { MethodsForTesting.FakePessoa(), MethodsForTesting.FakePessoa() },
                { MethodsForTesting.FakePessoa(), MethodsForTesting.FakePessoa() }
            };
        }
    }
}