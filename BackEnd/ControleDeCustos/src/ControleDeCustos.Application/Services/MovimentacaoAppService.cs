using ControleDeCustos.Application.Interfaces;
using System;
using System.Collections.Generic;
using ControleDeCustos.Application.ViewModels;
using ControleDeCustos.Domain.Interfaces;
using AutoMapper;
using ControleDeCustos.Domain.Entities;

namespace ControleDeCustos.Application.Services
{
    public class MovimentacaoAppService : IMovimentacaoAppService
    {
        private readonly IMovimentacaoRepository _movRepository;
        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public MovimentacaoAppService(IMovimentacaoRepository movRepository,
                                      IUser user,
                                      IUnitOfWork uow,
                                      IMapper mapper)
        {
            _movRepository = movRepository;
            _mapper = mapper;
            _uow = uow;
            _user = user;
        }

        public void Atualizar(MovimentacaoViewModel movimentacaoViewModel)
        {
            _movRepository.Atualizar(_mapper.Map<Movimentacao>(movimentacaoViewModel));
            _uow.Commit();
        }
        
        public void Excluir(Guid id)
        {
            _movRepository.Remover(id);
            _uow.Commit();
        }

        public MovimentacaoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<MovimentacaoViewModel>(_movRepository.ObterPorId(id));
        }

        public IEnumerable<MovimentacaoViewModel> ObterPorFiltros(Guid idFuncionario, string descricao)
        {
            return _mapper.Map<List<MovimentacaoViewModel>>(_movRepository.ObterPorFiltros(idFuncionario, descricao));
        }

        public IEnumerable<MovimentacaoViewModel> ObterTodos()
        {
            return _mapper.Map<List<MovimentacaoViewModel>>(_movRepository.ObterTodos());
        }

        public void Registrar(MovimentacaoViewModel movimentacaoViewModel)
        {
            _movRepository.Adicionar(_mapper.Map<Movimentacao>(movimentacaoViewModel));
            _uow.Commit();
        }

        public void Dispose()
        {
            _movRepository.Dispose();
        }
    }
}
