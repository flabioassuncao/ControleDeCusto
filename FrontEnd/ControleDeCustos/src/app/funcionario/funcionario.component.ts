import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Funcionario } from '../models/funcionario';
import { FuncionarioService } from '../services/funcionario.service';
import { DepartamentoService } from '../services/departamento.service';
import { Departamento } from '../models/departamento';
import { FuncionarioDepartamento } from '../models/funcionario_departamento';

@Component({
  selector: 'app-funcionario',
  templateUrl: './funcionario.component.html'
})
export class FuncionarioComponent implements OnInit {

  funcionarioForm: FormGroup;
  funcionarios: Funcionario[];
  funcionario: Funcionario = new Funcionario;
  departamentos: Departamento[];
  funcionarioDepartamento: FuncionarioDepartamento[] = [];

  constructor(private funService: FuncionarioService,
    private depService: DepartamentoService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.carrregarFuncionarios();
    this.carrregarDepartamentos();

    this.funcionarioForm = this.formBuilder.group({
      nome: this.formBuilder.control('', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]),
      departamento: this.formBuilder.control('', [])
    });
  }

  carrregarFuncionarios() {
    this.funService.funcionarios().subscribe(funcionarios => this.funcionarios = funcionarios);
  }

  carrregarDepartamentos() {
    this.depService.departamentos().subscribe(departamentos => this.departamentos = departamentos);
  }

  adicionarDepartamento() {
    const departamento = this.funcionarioForm.value.departamento;
    const dep = new FuncionarioDepartamento();
    dep.nome = departamento.nome;
    dep.departamentoId = departamento.id;
    if (this.funcionarioDepartamento.find(x => x.departamentoId === dep.departamentoId) === undefined) {
      this.funcionarioDepartamento.push(dep);
      // console.log(this.funcionarioDepartamento);
    }
  }

  removerDepartamento(departamento: FuncionarioDepartamento) {
    // console.log(departamento);
    const index: number = this.funcionarioDepartamento.indexOf(departamento);
    if (index !== -1) {
      this.funcionarioDepartamento.splice(index, 1);
    }
  }

  limparCampos() {
    this.funcionarioForm.reset();
  }

  registrarFuncionario() {
    // console.log(this.funcionarioForm.value);
    this.funcionario.nome =  this.funcionarioForm.value.nome;
    this.funcionario.departamentos = this.funcionarioDepartamento;

    // console.log(JSON.stringify(this.funcionario));

    this.funService.registrarFuncionario(this.funcionario)
      .subscribe(result => {
        this.limparCampos();
        this.carrregarFuncionarios();
      });
  }
}
