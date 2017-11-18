using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeCustos.Application.ViewModels
{
    public class FuncionarioDepartamentoViewModel
    {
        public FuncionarioDepartamentoViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid FuncionarioId { get; set; }
        public Guid DepartamentoId { get; set; }

        public FuncionarioViewModel Funcionario { get; set; }
        public DepartamentoViewModel Departamento { get; set; }
    }
}
