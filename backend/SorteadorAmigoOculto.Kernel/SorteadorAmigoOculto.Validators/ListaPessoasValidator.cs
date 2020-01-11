using System;
using System.Collections.Generic;
using SorteadorAmigoOculto.Model.Entity;

namespace SorteadorAmigoOculto.Validators
{
    public class ListaPessoasValidator
    {
        public static bool IsListaNula(List<Pessoa> pessoas) => pessoas == null;
        public static bool IsListaVazia(List<Pessoa> pessoas) => pessoas.Count == 0;
        public static bool IsSoUmaPessoaNaLista(List<Pessoa> pessoas) => pessoas.Count == 1;
        public static bool IsMaisDeDuasPessoasNaLista(List<Pessoa> pessoas) => pessoas.Count >= 2;
        public static bool ContainsNullNaLista(List<Pessoa> pessoas) => pessoas.Contains(null);
        public static bool IsPessoaPresenteNaLista(List<Pessoa> pessoas, Pessoa pessoa) => pessoas.Contains(pessoa);
        public static bool ContainsEmailDuplicadoNaLista(List<Pessoa> pessoas)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (Pessoa pessoa in pessoas)
            {
                if(dictionary.ContainsKey(pessoa.Email)) return true;
                dictionary.Add(pessoa.Email, pessoa.Nome);
            }

            return false;    
        }
        public static void ChecaListaPessoas(List<Pessoa> pessoas)
        {
            if (IsListaNula(pessoas)) throw new ArgumentNullException(nameof(pessoas));
            if (IsListaVazia(pessoas)) throw new InvalidOperationException("The list passed as argument is empty.");
            if (IsSoUmaPessoaNaLista(pessoas)) throw new InvalidOperationException("The list passed has only one person.");
            if (ContainsNullNaLista(pessoas)) throw new NullReferenceException("The list has a null object inside of it.");
            if (ContainsEmailDuplicadoNaLista(pessoas)) throw new InvalidOperationException("The list contains a duplicated e-mail.");
        }
    }
}
