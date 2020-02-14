using SorteadorAmigoOculto.Kernel.Model.DTO;
using System.Collections.Generic;

namespace SorteadorAmigoOculto.Interfaces.Business
{
    public interface ISorteioBusiness
    {
        void FazSorteio(List<PessoaDTO> pessoas);
    }
}