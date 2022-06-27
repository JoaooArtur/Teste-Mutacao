using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Entities
{
    public class Funcionario
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int Idade { get; set; }
    }
}
