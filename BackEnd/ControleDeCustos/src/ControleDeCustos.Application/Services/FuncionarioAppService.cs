using ControleDeCustos.Application.Interfaces;
using System;
using System.Collections.Generic;
using ControleDeCustos.Application.ViewModels;
using ControleDeCustos.Domain.Interfaces;
using AutoMapper;
using ControleDeCustos.Domain.Entities;

namespace ControleDeCustos.Application.Services
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IFuncionarioRepository _funcRepository;
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public FuncionarioAppService(IFuncionarioRepository funcRepository,
                                     IMapper mapper,
                                     IUser user)
        {
            _funcRepository = funcRepository;
            _mapper = mapper;
            _user = user;
        }

        public void Atualizar(FuncionarioViewModel funcionarioViewModel)
        {
            _funcRepository.Atualizar(_mapper.Map<Funcionario>(funcionarioViewModel));
        }
        
        public void Excluir(Guid id)
        {
            _funcRepository.Remover(id);
        }

        public FuncionarioViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<FuncionarioViewModel>(_funcRepository.ObterPorId(id));
        }

        public IEnumerable<FuncionarioViewModel> ObterTodos()
        {
            return _mapper.Map<List<FuncionarioViewModel>>(_funcRepository.ObterTodos());
        }

        public void Registrar(FuncionarioViewModel funcionarioViewModel)
        {
            _funcRepository.Adicionar(_mapper.Map<Funcionario>(funcionarioViewModel));
        }

        public void Dispose()
        {
            _funcRepository.Dispose();
        }
    }
}
