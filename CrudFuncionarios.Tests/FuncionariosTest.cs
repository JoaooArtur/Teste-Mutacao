using Application.Core.Application;
using Application.Core.Application.Interfaces;
using Application.Core.Entities;
using Application.Core.Validations;
using System;
using System.ComponentModel;
using Xunit;

namespace CrudFuncionarios.Tests
{
    public class FuncionariosTest
    {

        [Fact]
        [Trait("Funcionarios", "Codigo")]
        [Description("Retorna uma exception se C�digo � Guid Empty.")]
        public void ValidaCodigoFuncionario_ShouldReturnException_WhenCodigoIsEmpty()
        {
            var codigo = new Guid();
            var ex = Assert.Throws<Exception>(() => FuncionarioValidation.ValidaCodigoFuncionario(codigo));

            //Assert
            Assert.Equal("C�digo informado inv�lido", ex.Message);
        }

        [Fact]
        [Trait("Funcionarios", "Documento")]
        [Description("Retorna uma exception se Documento0 � null.")]
        public void ValidaFuncionario_ShouldReturnException_WhenDocumentoIsNull()
        {
            var funcionario = new Funcionario 
            {
                Documento = null,
                Idade = 19,
                Nome = "Jo�o"
            };
            var ex = Assert.Throws<Exception>(() => FuncionarioValidation.ValidaFuncionario(funcionario));

            //Assert
            Assert.Equal("Documento inv�lido", ex.Message);
        }

        [Fact]
        [Trait("Funcionarios", "Documento")]
        [Description("Retorna uma exception se Documento � Empty.")]
        public void ValidaCodigoFuncionario_ShouldReturnException_WhenDocumentoIsEmpty()
        {
            var funcionario = new Funcionario
            {
                Documento = "",
                Idade = 19,
                Nome = "Jo�o"
            };
            var ex = Assert.Throws<Exception>(() => FuncionarioValidation.ValidaFuncionario(funcionario));

            //Assert
            Assert.Equal("Documento inv�lido", ex.Message);
        }

        [Fact]
        [Trait("Funcionarios", "Idade")]
        [Description("Retorna uma exception se Idade � menor a zero.")]
        public void ValidaCodigoFuncionario_ShouldReturnException_WhenIdadeIsNegative()
        {
            var funcionario = new Funcionario
            {
                Documento = "12343143156",
                Idade = -1,
                Nome = "Jo�o"
            };
            var ex = Assert.Throws<Exception>(() => FuncionarioValidation.ValidaFuncionario(funcionario));

            //Assert
            Assert.Equal("Idade informada inv�lida", ex.Message);
        }

        [Fact]
        [Trait("Funcionarios", "Idade")]
        [Description("Retorna uma exception se Idade � igual a zero.")]
        public void ValidaCodigoFuncionario_ShouldReturnException_WhenIdadeIsZero()
        {
            var funcionario = new Funcionario
            {
                Documento = "12343143156",
                Idade = 0,
                Nome = "Jo�o"
            };
            var ex = Assert.Throws<Exception>(() => FuncionarioValidation.ValidaFuncionario(funcionario));

            //Assert
            Assert.Equal("Idade informada inv�lida", ex.Message);
        }

        [Fact]
        [Trait("Funcionarios", "Nome")]
        [Description("Retorna uma exception se Nome � null.")]
        public void ValidaFuncionario_ShouldReturnException_WhenNomeIsNull()
        {
            var funcionario = new Funcionario
            {
                Documento = "12343143156",
                Idade = 19,
                Nome = null
            };
            var ex = Assert.Throws<Exception>(() => FuncionarioValidation.ValidaFuncionario(funcionario));

            //Assert
            Assert.Equal("Nome informado inv�lido", ex.Message);
        }

        [Fact]
        [Trait("Funcionarios", "Nome")]
        [Description("Retorna uma exception se Nome � Empty.")]
        public void ValidaCodigoFuncionario_ShouldReturnException_WhenNomeIsEmpty()
        {
            var funcionario = new Funcionario
            {
                Documento = "12343143156",
                Idade = 19,
                Nome = ""
            };
            var ex = Assert.Throws<Exception>(() => FuncionarioValidation.ValidaFuncionario(funcionario));

            //Assert
            Assert.Equal("Nome informado inv�lido", ex.Message);
        }
    }
}
