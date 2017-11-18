using System;
using System.Collections.Generic;

namespace ControleDeCustos.Domain.Entities
{
    public class Departamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<FuncionarioDepartamento> Funcionarios { get; set; }
    }
}
