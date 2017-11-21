using ControleDeCustos.Application.Interfaces;
using System;
using System.Collections.Generic;
using ControleDeCustos.Application.ViewModels;
using AutoMapper;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Domain.Entities;

namespace ControleDeCustos.Application.Services
{
    public class DepartamentoAppService : IDepartamentoAppService
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IUser _user;
        private readonly IUnitOfWork _uow;

        public DepartamentoAppService(IMapper mapper,
                                      IDepartamentoRepository departamentoRepository,
                                      IUnitOfWork uow,
                                      IUser user)
        {
            _mapper = mapper;
            _departamentoRepository = departamentoRepository;
            _uow = uow;
            _user = user;
        }

        public void Atualizar(DepartamentoViewModel departamentoViewModel)
        {
            _departamentoRepository.Atualizar(_mapper.Map<Departamento>(departamentoViewModel));
            _uow.Commit();
        }
        
        public void Excluir(Guid id)
        {
            _departamentoRepository.Remover(id);
            _uow.Commit();
        }

        public DepartamentoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<DepartamentoViewModel>(_departamentoRepository.ObterPorId(id));
        }
        
        public IEnumerable<DepartamentoViewModel> ObterTodos()
        {
            return _mapper.Map<List<DepartamentoViewModel>>(_departamentoRepository.ObterTodos());
        }

        public void Registrar(DepartamentoViewModel departamentoViewModel)
        {
            _departamentoRepository.Adicionar(_mapper.Map<Departamento>(departamentoViewModel));
            _uow.Commit();
        }

        public void Dispose()
        {
            _departamentoRepository.Dispose();
        }
    }
}
