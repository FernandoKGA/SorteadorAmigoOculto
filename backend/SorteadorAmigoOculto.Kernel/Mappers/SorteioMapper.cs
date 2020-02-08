using SorteadorAmigoOculto.Kernel.Model.DTO;
using SorteadorAmigoOculto.Kernel.Model.Entity;

namespace SorteadorAmigoOculto.Kernel.Mappers
{
    public static class SorteioMapper
    {
        public static SorteioDTO ToSorteioDTO(Sorteio sorteio){
            return new SorteioDTO(
                sorteio.IdentificadorSorteio, 
                PessoaMapper.ToDictionaryPessoaDTO(sorteio.PessoasSorteadas)
            );
        }
    }
}