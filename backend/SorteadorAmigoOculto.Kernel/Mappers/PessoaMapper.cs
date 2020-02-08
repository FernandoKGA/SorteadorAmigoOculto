using System.Collections.Generic;
using SorteadorAmigoOculto.Kernel.Model.DTO;
using SorteadorAmigoOculto.Kernel.Model.Entity;

namespace SorteadorAmigoOculto.Kernel.Mappers
{
    public static class PessoaMapper
    {
        public static PessoaDTO ToPessoaDTO(Pessoa pessoa){
            return new PessoaDTO{
                Email = pessoa.Email,
                Nome = pessoa.Nome
            };
        }

        public static Dictionary<PessoaDTO,PessoaDTO> ToDictionaryPessoaDTO(Dictionary<Pessoa,Pessoa> dicionarioPessoas){
            var dicionarioPessoasDTO = new Dictionary<PessoaDTO,PessoaDTO>();
            foreach(KeyValuePair<Pessoa,Pessoa> pessoa in dicionarioPessoas){
                dicionarioPessoasDTO.Add(
                    ToPessoaDTO(pessoa.Key),
                    ToPessoaDTO(pessoa.Value)
                );
            }
            return dicionarioPessoasDTO;
        }
    }
}