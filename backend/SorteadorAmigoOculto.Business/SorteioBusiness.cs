using System.Collections.Generic;
using SorteadorAmigoOculto.Interfaces.Business;
using SorteadorAmigoOculto.Kernel.Mappers;
using SorteadorAmigoOculto.Kernel.Model.DTO;
using SorteadorAmigoOculto.Kernel.Model.Entity;

namespace SorteadorAmigoOculto.Business
{
    public class SorteioBusiness : ISorteioBusiness
    {
        private readonly ISorteadorBusiness sorteadorBusiness;
        public SorteioBusiness(ISorteadorBusiness sorteadorBusiness)
        {
            this.sorteadorBusiness = sorteadorBusiness;
        }
        
        private Sorteio GeraSorteio(Dictionary<Pessoa,Pessoa> dicionarioPessoas){
            return new Sorteio(dicionarioPessoas);
        }

        public void FazSorteio(List<PessoaDTO> pessoas){
            var listaPessoas = PessoaMapper.ToListPessoaEntity(pessoas);
            var dicionarioPessoas = sorteadorBusiness.SortearAmigoOculto(listaPessoas);
            var sorteio = GeraSorteio(dicionarioPessoas);
            // pega o sorteio e manda e-mail
        }
    }
}