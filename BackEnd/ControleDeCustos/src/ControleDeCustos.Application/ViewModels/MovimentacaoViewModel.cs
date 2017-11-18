using System;

namespace ControleDeCustos.Application.ViewModels
{
    public class MovimentacaoViewModel
    {
        public MovimentacaoViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public virtual FuncionarioViewModel Funcionario { get; set; }
    }
}
