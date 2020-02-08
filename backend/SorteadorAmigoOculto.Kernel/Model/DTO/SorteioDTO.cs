using System.Collections.Generic;
using System;

namespace SorteadorAmigoOculto.Kernel.Model.DTO
{
    public class SorteioDTO
    {
        public SorteioDTO(Guid identificadorSorteio, Dictionary<PessoaDTO,PessoaDTO> dicionarioPessoas){
            IdentificadorSorteio = identificadorSorteio;
            PessoasSorteadas = dicionarioPessoas;
        }

        public Guid IdentificadorSorteio {get; private set;}
        public Dictionary<PessoaDTO,PessoaDTO> PessoasSorteadas {get; private set;}
    }
}