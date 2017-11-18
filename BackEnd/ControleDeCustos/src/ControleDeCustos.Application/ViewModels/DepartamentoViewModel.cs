using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleDeCustos.Application.ViewModels
{
    public class DepartamentoViewModel
    {
        public DepartamentoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ICollection<FuncionarioDepartamentoViewModel> Funcionarios { get; set; }
    }
}
