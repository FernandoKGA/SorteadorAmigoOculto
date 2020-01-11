using System;
using System.Collections.Generic;
using SorteadorAmigoOculto.Model.Entity;

namespace SorteadorAmigoOculto.Validators
{
    public class ListaPessoasValidator
    {
        public static bool IsListaNula(List<Pessoa> pessoas)
        {
            return pessoas == null;
        }

        public static bool IsListaVazia(List<Pessoa> pessoas)
        {
            return pessoas.Count == 0;
        }

        public static bool IsSoUmaPessoaNaLista(List<Pessoa> pessoas)
        {
            return pessoas.Count == 1;
        }

        public static bool IsMaisDeDuasPessoasNaLista(List<Pessoa> pessoas)
        {
            return pessoas.Count >= 2;
        }

        public static bool ContainsNullNaLista(List<Pessoa> pessoas)
        {
            return pessoas.Contains(null);
        }
    }
}
