using System.Collections.Generic;
using System;
namespace SorteadorAmigoOculto.Kernel.Model.Entity
{
    public class Sorteio
    {
        public Sorteio(Dictionary<Pessoa,Pessoa> dicionarioSorteio)
        {
            IdentificadorSorteio = new Guid();
            PessoasSorteadas = dicionarioSorteio;
        }
        public Guid IdentificadorSorteio {get; private set;}
        public Dictionary<Pessoa,Pessoa> PessoasSorteadas {get; private set;}
    }
}