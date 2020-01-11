using System.Linq;
using System;
using System.Collections.Generic;
using SorteadorAmigoOculto.Interfaces.Business;
using SorteadorAmigoOculto.Model.Entity;
using SorteadorAmigoOculto.Helpers;
using SorteadorAmigoOculto.Validators;

namespace SorteadorAmigoOculto.Business
{
    public class SorteadorBusiness : ISorteadorBusiness
    {
        public Dictionary<Pessoa, Pessoa> SorteiaAmigoOculto(List<Pessoa> pessoas)
        {
            ChecaLista(pessoas);

            Dictionary<Pessoa,Pessoa> listaSorteada = new Dictionary<Pessoa, Pessoa>();
            
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

        private void ChecaLista(List<Pessoa> pessoas)
        {
            switch(pessoas)
            {
                ListaPessoasValidator.IsListaNula(pessoas) => throw new ArgumentNullException(nameof(pessoas))
            };
            
            if (ListaPessoasValidator.IsListaNula(pessoas)) throw new ArgumentNullException(nameof(pessoas));
            if (ListaPessoasValidator.IsListaVazia(pessoas)) throw new InvalidOperationException("The list passed as argument is empty.");
            if (ListaPessoasValidator.IsSoUmaPessoaNaLista(pessoas)) throw new InvalidOperationException("The list passed has only one person.");
            if (ListaPessoasValidator.ContainsNullNaLista(pessoas)) throw new NullReferenceException("The list has a null object inside of it.");

            
        }
    }
}