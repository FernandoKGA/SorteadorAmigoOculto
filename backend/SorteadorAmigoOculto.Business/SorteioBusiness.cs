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
        private readonly IEmailBusiness emailBusiness;
        public SorteioBusiness(ISorteadorBusiness sorteadorBusiness, IEmailBusiness emailBusiness)
        {
            this.sorteadorBusiness = sorteadorBusiness;
            this.emailBusiness = emailBusiness;
        }
        
        private Sorteio GeraSorteio(Dictionary<Pessoa,Pessoa> dicionarioPessoas){
            return new Sorteio(dicionarioPessoas);
        }

        public void FazSorteio(List<PessoaDTO> pessoas){
            var listaPessoas = PessoaMapper.ToListPessoaEntity(pessoas);
            var dicionarioPessoas = sorteadorBusiness.SortearAmigoOculto(listaPessoas);
            var sorteio = GeraSorteio(dicionarioPessoas);
            emailBusiness.EnviaSorteio(SorteioMapper.ToSorteioDTO(sorteio));
        }
    }
}