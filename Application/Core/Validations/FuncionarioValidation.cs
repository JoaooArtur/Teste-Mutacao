using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Validations
{
    public static class FuncionarioValidation
    {

        public static void ValidaFuncionario(Funcionario funcionario)
        {
            if (string.IsNullOrWhiteSpace(funcionario.Documento))
                throw new Exception("Documento inválido");

            if (funcionario.Idade <= 0)
                throw new Exception("Idade informada inválida");

            if (string.IsNullOrWhiteSpace(funcionario.Nome))
                throw new Exception("Nome informado inválido");
        }

        public static void ValidaCodigoFuncionario(Guid codigo)
        {
            if (codigo ==  Guid.Empty)
                throw new Exception("Código informado inválido");
        }
    }
}
