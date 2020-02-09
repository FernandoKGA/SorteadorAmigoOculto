using System.Linq;
using System;
using System.Collections.Generic;
using SorteadorAmigoOculto.Interfaces.Business;
using SorteadorAmigoOculto.Kernel.Model.Entity;
using SorteadorAmigoOculto.Kernel.Helpers;
using SorteadorAmigoOculto.Kernel.Validators;

namespace SorteadorAmigoOculto.Business
{
    public class SorteadorBusiness : ISorteadorBusiness
    {
        public Dictionary<Pessoa, Pessoa> SortearAmigoOculto(List<Pessoa> pessoas){
            PessoaValidator.ChecaListaPessoas(pessoas);
            return SorteiaAmigoOculto(pessoas);
        }
        private Dictionary<Pessoa, Pessoa> SorteiaAmigoOculto(List<Pessoa> pessoas)
        {
            var listaSorteada = new Dictionary<Pessoa, Pessoa>();
            
            var pessoasASeremTiradas = pessoas.Select(x => x).ToList();
            
            while(pessoas.Count != 0){
                pessoas.Shuffle();
                pessoasASeremTiradas.Shuffle();
                Pessoa pessoaTirou = pessoas.First();
                Pessoa pessoaTirada = pessoasASeremTiradas.First();

                if(pessoaTirou.Equals(pessoaTirada)) continue;

                listaSorteada.Add(pessoaTirou,pessoaTirada);

                pessoas.Remove(pessoaTirou);
                pessoasASeremTiradas.Remove(pessoaTirada);
            }

            return listaSorteada;
        }
    }
}