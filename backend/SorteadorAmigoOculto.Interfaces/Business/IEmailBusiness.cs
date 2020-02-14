using SorteadorAmigoOculto.Kernel.Model.DTO;

namespace SorteadorAmigoOculto.Interfaces.Business
{
    public interface IEmailBusiness
    {
        void EnviaSorteio(SorteioDTO sorteioDTO);
    }
}