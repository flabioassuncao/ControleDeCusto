import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Funcionario } from '../models/funcionario';
import { Movimentacao } from '../models/movimentacao';
import { FuncionarioService } from '../services/funcionario.service';
import { MovimentacaoService } from '../services/movimentacao.service';
import { Router } from '@angular/router';
import { NotificationService } from '../notificacao/notification.service';
import { error } from 'selenium-webdriver';

@Component({
  selector: 'app-movimentacao',
  templateUrl: './movimentacao.component.html'
})
export class MovimentacaoComponent implements OnInit {

  numberPattern = /^\d+(\.\d{1,2})?$/;

  movimentacaoForm: FormGroup;
  funcionarios: Funcionario[];
  movimentacoes: Movimentacao[];
  movimentacao: Movimentacao = new Movimentacao;

  funcionarioIdFilter: string;
  descricaoFilter = '';

  constructor(private funService: FuncionarioService,
    private movService: MovimentacaoService,
    private formBuilder: FormBuilder,
    private router: Router,
    private notification: NotificationService) { }

  ngOnInit() {
    this.carrregarFuncionarios();
    this.carrregarMovimentacoes();

    this.movimentacaoForm = this.formBuilder.group({
      descricao: this.formBuilder.control('', [Validators.required, Validators.minLength(2), Validators.maxLength(500)]),
      funcionarioId: this.formBuilder.control('', [Validators.required]),
      valor: this.formBuilder.control('', [Validators.required, Validators.pattern(this.numberPattern)])
    });
  }

  carrregarFuncionarios() {
    this.funService.funcionarios().subscribe(funcionarios => {
      this.funcionarios = funcionarios;
    },
    erros => {
      this.errorRequisicao(erros);
    });
  }

  carrregarMovimentacoes() {
    this.movService.movimentacaoes().subscribe(movimentacoes => {
      this.movimentacoes = movimentacoes;
    },
    erros => {
      this.errorRequisicao(erros);
    });
  }

  limparCampos() {
    this.movimentacaoForm.reset();
  }

  registrarMovimentacao() {
    this.movimentacao.descricao = this.movimentacaoForm.value.descricao;
    this.movimentacao.valor = this.movimentacaoForm.value.valor;
    this.movimentacao.funcionarioId = this.movimentacaoForm.value.funcionarioId;

    this.movService.registrarMovimentacao(this.movimentacao)
      .subscribe(result => {
        this.limparCampos();
        this.carrregarMovimentacoes();
      },
      erros => {
        this.errorRequisicao(erros);
      });
  }

  filtrarMovimentacoes() {
    this.movService.movimentacaoesFiltradas(this.funcionarioIdFilter, this.descricaoFilter)
      .subscribe(movimentacoes => {
        this.movimentacoes = movimentacoes;
      },
      erros => {
        this.errorRequisicao(erros);
      });
  }

  limparFiltros() {
    this.funcionarioIdFilter = '0';
    this.descricaoFilter = '';
    this.movService.movimentacaoesFiltradas(this.funcionarioIdFilter, this.descricaoFilter)
      .subscribe(movimentacoes => this.movimentacoes = movimentacoes);
  }

  errorRequisicao(erro: any) {
    if (erro.status === 401) {
      this.notification.notify('Acesso expirado, logue novamente!');
      localStorage.clear();
      this.router.navigate(['/acesso']);
    } else {
      this.notification.notify('Erro ao processar solicitação, tente novamente!');
    }
  }

}
