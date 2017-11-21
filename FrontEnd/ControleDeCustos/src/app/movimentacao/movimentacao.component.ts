import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Funcionario } from '../models/funcionario';
import { Movimentacao } from '../models/movimentacao';
import { FuncionarioService } from '../services/funcionario.service';
import { MovimentacaoService } from '../services/movimentacao.service';

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

  constructor(private funService: FuncionarioService,
    private movService: MovimentacaoService,
    private formBuilder: FormBuilder) { }

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
    this.funService.funcionarios().subscribe(funcionarios => this.funcionarios = funcionarios);
  }

  carrregarMovimentacoes() {
    this.movService.movimentacaoes().subscribe(movimentacoes => this.movimentacoes = movimentacoes);
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
      });
  }

  FiltrarMovimentacoes() {
    console.log(this.funcionarioIdFilter);
  }

}
