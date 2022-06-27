using Application.Core.Application.Interfaces;
using Application.Core.Entities;
using Application.Core.Repository.Interfaces;
using Application.Core.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Application
{
    public class FuncionariosApplicationService : IFuncionariosApplicationService
    {
        private readonly IFuncionariosRepository _repository;

        public FuncionariosApplicationService(IFuncionariosRepository repository)
        {
            _repository = repository;
        }

        public Funcionario Insert(Funcionario funcionario)
        {
            FuncionarioValidation.ValidaFuncionario(funcionario);
            var response = _repository.Insert(funcionario);
            return response.Result;
        }

        public void Update(Guid codigo,Funcionario funcionario)
        {
            FuncionarioValidation.ValidaCodigoFuncionario(codigo);
            FuncionarioValidation.ValidaFuncionario(funcionario);
            _repository.Update(codigo,funcionario);
        }

        public void Delete(Guid codigo)
        {
            FuncionarioValidation.ValidaCodigoFuncionario(codigo);
            _repository.Delete(codigo);
        }

        public Funcionario Get(Guid codigo)
        {
            FuncionarioValidation.ValidaCodigoFuncionario(codigo);

            var response = _repository.Get(codigo);
            return response.Result;
        }
    }
}
