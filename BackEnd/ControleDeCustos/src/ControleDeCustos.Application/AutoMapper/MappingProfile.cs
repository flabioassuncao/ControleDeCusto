using AutoMapper;
using ControleDeCustos.Application.DTO;
using ControleDeCustos.Application.ViewModels;
using ControleDeCustos.Domain.Entities;

namespace ControleDeCustos.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Departamento, DepartamentoViewModel>().ReverseMap();
            CreateMap<Movimentacao, MovimentacaoViewModel>().ReverseMap();
            CreateMap<FuncionarioDepartamento, FuncionarioDepartamentoViewModel>().ReverseMap();

            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
        }
    }
}
