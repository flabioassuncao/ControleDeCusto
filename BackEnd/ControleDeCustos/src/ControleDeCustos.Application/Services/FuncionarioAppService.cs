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
        private readonly IFuncionarioDepartamentoRepository _funcDepRepository;
        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FuncionarioAppService(IFuncionarioRepository funcRepository,
                                     IFuncionarioDepartamentoRepository funcDepRepository,
                                     IMapper mapper,
                                     IUnitOfWork uow,
                                     IUser user)
        {
            _funcRepository = funcRepository;
            _funcDepRepository = funcDepRepository;
            _mapper = mapper;
            _uow = uow;
            _user = user;
        }

        public void Atualizar(FuncionarioViewModel funcionarioViewModel)
        {
            _funcRepository.Atualizar(_mapper.Map<Funcionario>(funcionarioViewModel));
            _uow.Commit();
        }
        
        public void Excluir(Guid id)
        {
            _funcRepository.Remover(id);
            _uow.Commit();
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

            _uow.Commit();
        }

        public void Dispose()
        {
            _funcRepository.Dispose();
        }
    }
}
