using System;
using System.Collections.Generic;
using SorteadorAmigoOculto.Kernel.Model.DTO;
using SorteadorAmigoOculto.Kernel.Model.Entity;

namespace SorteadorAmigoOculto.Kernel.Mappers
{
    public static class PessoaMapper
    {
        public static Pessoa ToPessoaEntity(PessoaDTO pessoaDTO){
            return new Pessoa{
                Email = pessoaDTO.Email,
                Nome = pessoaDTO.Nome
            };
        }

        public static List<Pessoa> ToListPessoaEntity(List<PessoaDTO> listaPessoasDTO){
            var listaPessoas = new List<Pessoa>();
            foreach(PessoaDTO pessoaDTO in listaPessoasDTO){
                listaPessoas.Add(ToPessoaEntity(pessoaDTO));
            }
            return listaPessoas;
        }

        public static PessoaDTO ToPessoaDTO(Pessoa pessoa){
            return new PessoaDTO{
                Email = pessoa.Email,
                Nome = pessoa.Nome
            };
        }

        public static Dictionary<PessoaDTO,PessoaDTO> ToDictionaryPessoaDTO(Dictionary<Pessoa,Pessoa> dicionarioPessoas){
            if (dicionarioPessoas == null) throw new ArgumentNullException(nameof(dicionarioPessoas));
            if (dicionarioPessoas.Count == 0) throw new ArgumentOutOfRangeException(nameof(dicionarioPessoas));

            var dicionarioPessoasDTO = new Dictionary<PessoaDTO,PessoaDTO>();
            foreach(KeyValuePair<Pessoa,Pessoa> pessoa in dicionarioPessoas){
                if(pessoa.Value == null) throw new NullReferenceException(nameof(pessoa.Value));
                dicionarioPessoasDTO.Add(
                    ToPessoaDTO(pessoa.Key),
                    ToPessoaDTO(pessoa.Value)
                );
            }
            return dicionarioPessoasDTO;
        }
    }
}