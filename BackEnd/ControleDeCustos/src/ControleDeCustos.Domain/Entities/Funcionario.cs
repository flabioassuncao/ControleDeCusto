using System;
using System.Collections.Generic;

namespace ControleDeCustos.Domain.Entities
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        //public Guid IdAcesso { get; set; }

        public virtual ICollection<FuncionarioDepartamento> Departamentos { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}
