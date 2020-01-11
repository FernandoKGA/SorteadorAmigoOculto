using System.Collections.Generic;
using SorteadorAmigoOculto.Model.Entity;

namespace SorteadorAmigoOculto.Interfaces.Business
{
    public interface ISorteadorBusiness
    {
        Dictionary<Pessoa,Pessoa> SortearAmigoOculto(List<Pessoa> pessoas);
    }
}