using System;
using System.Collections.Generic;

namespace ControleDeCustos.Application.DTO
{
    public class FuncionarioDTO
    {
        public FuncionarioDTO()
        {
            Departamentos = new List<DepartamentoDTO>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ICollection<DepartamentoDTO> Departamentos { get; set; }
    }
}
