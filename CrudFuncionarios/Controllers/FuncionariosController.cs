using Application.Core.Application.Interfaces;
using Application.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFuncionarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionariosApplicationService _funcionariosApplicationService;

        public FuncionariosController(IFuncionariosApplicationService funcionariosApplicationService)
        {
            _funcionariosApplicationService = funcionariosApplicationService;
        }

        [HttpGet]
        public IActionResult GetAll(Guid codigo)
        {
            var response = _funcionariosApplicationService.Get(codigo);
            return Ok(response);
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(Guid codigo)
        {
            _funcionariosApplicationService.Delete(codigo);
            return NoContent();
        }

        [HttpPut("{codigo}")]
        public IActionResult Put(Guid codigo,[FromBody] Funcionario funcionario)
        {
            _funcionariosApplicationService.Update(codigo,funcionario);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(Funcionario funcionario)
        {
            var response =_funcionariosApplicationService.Insert(funcionario);
            return Created("Funcionario",response);
        }
    }
}
