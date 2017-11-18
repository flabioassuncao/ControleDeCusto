using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeCustos.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public FuncionarioViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<FuncionarioDepartamentoViewModel> Departamentos { get; set; }
    }
}
