using System;

namespace ControleDeCustos.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public Guid FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}
