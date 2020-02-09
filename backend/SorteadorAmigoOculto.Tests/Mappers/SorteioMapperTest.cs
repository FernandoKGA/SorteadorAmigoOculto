using SorteadorAmigoOculto.Kernel.Mappers;
using SorteadorAmigoOculto.Kernel.Model.Entity;
using Xunit;

namespace SorteadorAmigoOculto.Tests.Mappers
{
    public class SorteioMapperTest
    {
        [Fact]
        public void ToSorteioDTO(){
            //Arrange
            var dicionarioPessoas = MethodsForTesting.GenerateDicionarioPessoas();
            var sorteio = new Sorteio(dicionarioPessoas);

            //Act
            var result = SorteioMapper.ToSorteioDTO(sorteio);

            //Assert
            Assert.True(sorteio.IdentificadorSorteio == result.IdentificadorSorteio);
        }
    }
}