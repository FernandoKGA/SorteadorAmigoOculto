using SorteadorAmigoOculto.Models.Entity;

using System.Collections.Generic;

namespace SorteadorAmigoOculto.API.Business.Interfaces
{
    public interface ISorteadorBusiness
    {
        Dictionary<Pessoa, Pessoa> SorteiaAmigoOculto(List<Pessoa> pessoas);
    }
}