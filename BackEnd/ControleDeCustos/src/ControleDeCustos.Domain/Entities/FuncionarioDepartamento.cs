using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeCustos.Domain.Entities
{
    public class FuncionarioDepartamento
    {
        public Guid Id { get; set; }

        public Guid FuncionarioId { get; set; }
        public Guid DepartamentoId { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
