using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;
using SorteadorAmigoOculto.Kernel.Mappers;
using SorteadorAmigoOculto.Kernel.Model.Entity;
using SorteadorAmigoOculto.Kernel.Model.DTO;

namespace SorteadorAmigoOculto.Tests
{
    public class PessoaMapperTest
    {
        
        [Fact]
        public void ToPessoaDTO(){
            //Arrange
            var pessoaFake = MethodsForTesting.FakePessoa();

            //Act
            var pessoaFakeDTO = PessoaMapper.ToPessoaDTO(pessoaFake);

            //Assert
            Assert.Equal(pessoaFake.Email, pessoaFakeDTO.Email);
            Assert.Equal(pessoaFake.Nome, pessoaFakeDTO.Nome);
        }

        [Fact]
        public void ToDictionaryPessoaDTONullException(){
            //Assert
            Assert.Throws<ArgumentNullException>(() => PessoaMapper.ToDictionaryPessoaDTO(null));
        }

        [Fact]
        public void ToDictionaryPessoaDTOEmptyList(){
            //Arrange
            var dicionarioPessoas = new Dictionary<Pessoa,Pessoa>();

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => PessoaMapper.ToDictionaryPessoaDTO(dicionarioPessoas));
        }

        [Fact]
        public void ToDictionaryPessoaDTONullableValue(){
            //Arrange
            var dicionarioPessoas = GenerateDicionarioPessoasComUmaNula();

            //Assert
            Assert.Throws<NullReferenceException>(() => PessoaMapper.ToDictionaryPessoaDTO(dicionarioPessoas));
        }

        [Fact]
        public void ToDictionaryPessoaDTO(){
            //Arrange
            var dicionarioPessoas = MethodsForTesting.GenerateDicionarioPessoas();

            //Act
            var result = PessoaMapper.ToDictionaryPessoaDTO(dicionarioPessoas);

            //Assert
            foreach(var parvalor in dicionarioPessoas){
                var parvalorDTO = BuscaSeTemPessoaRegistradaNoDicionario(
                    parvalor, result
                );
                Assert.True(VerificaSeTemMesmoNomeEEmail(parvalor.Key, parvalorDTO.Key));
                Assert.True(VerificaSeTemMesmoNomeEEmail(parvalor.Value, parvalorDTO.Value));
            }
        }

        [Fact]
        public void ToPessoaEntity(){
            //Arrange
            var pessoaFakeDTO = MethodsForTesting.FakePessoaDTO();
            
            //Act
            var pessoa = PessoaMapper.ToPessoaEntity(pessoaFakeDTO);

            //Assert
            Assert.True(VerificaSeTemMesmoNomeEEmail(pessoa,pessoaFakeDTO));
        }

        [Fact]
        public void ToListPessoaEntity(){
            //Arrange
            var listaPessoasDTO = new List<PessoaDTO>();
            for(int i = 0; i < 5; i++){
                listaPessoasDTO.Add(MethodsForTesting.FakePessoaDTO());
            }
            
            //Act
            var listaPessoas = PessoaMapper.ToListPessoaEntity(listaPessoasDTO);

            //Assert
            foreach(var pessoaDTO in listaPessoasDTO){
                var pessoa = BuscaSeTemPessoaRegistradaNaLista(pessoaDTO, listaPessoas);
                Assert.True(VerificaSeTemMesmoNomeEEmail(pessoa,pessoaDTO));    
            }
        }

        private Pessoa BuscaSeTemPessoaRegistradaNaLista(
            PessoaDTO pessoaDTO,
            List<Pessoa> listaPessoas
        ){
            return listaPessoas.AsQueryable().Where(x => 
            VerificaSeTemMesmoNomeEEmail(x, pessoaDTO)).ToList().Single();
        }
        
        private KeyValuePair<PessoaDTO,PessoaDTO> BuscaSeTemPessoaRegistradaNoDicionario(
            KeyValuePair<Pessoa,Pessoa> pessoa,
            Dictionary<PessoaDTO,PessoaDTO> dicionarioPessoaDTO
        ){
            return dicionarioPessoaDTO.AsQueryable().Where(x => 
            VerificaSeTemMesmoNomeEEmail(pessoa.Key, x.Key)).ToList().Single();
        }

        private bool VerificaSeTemMesmoNomeEEmail(Pessoa pessoa, PessoaDTO pessoaDTO){
            return pessoa.Email == pessoaDTO.Email && pessoa.Nome == pessoaDTO.Nome;
        }

        private Dictionary<Pessoa,Pessoa> GenerateDicionarioPessoasComUmaNula(){
            return new Dictionary<Pessoa, Pessoa>{
                { MethodsForTesting.FakePessoa(), MethodsForTesting.FakePessoa() },
                { MethodsForTesting.FakePessoa(), null }
            };
        }
    }
}