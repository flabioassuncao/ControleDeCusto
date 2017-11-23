import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Funcionario } from '../models/funcionario';
import { FuncionarioService } from '../services/funcionario.service';
import { DepartamentoService } from '../services/departamento.service';
import { Departamento } from '../models/departamento';
import { FuncionarioDepartamento } from '../models/funcionario_departamento';
import { Router } from '@angular/router';

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
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    this.carrregarFuncionarios();
    this.carrregarDepartamentos();

    this.funcionarioForm = this.formBuilder.group({
      nome: this.formBuilder.control('', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]),
      departamento: this.formBuilder.control('', [])
    });
  }

  carrregarFuncionarios() {
    this.funService.funcionarios().subscribe(funcionarios => {
      this.funcionarios = funcionarios;
    },
    reponse => {
      localStorage.clear();
      this.router.navigate(['/acesso']);
    });
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
    }
  }

  removerDepartamento(departamento: FuncionarioDepartamento) {
    const index: number = this.funcionarioDepartamento.indexOf(departamento);
    if (index !== -1) {
      this.funcionarioDepartamento.splice(index, 1);
    }
  }

  limparCampos() {
    this.funcionarioForm.reset();
    this.funcionarioDepartamento = [];
  }

  registrarFuncionario() {
    this.funcionario.nome =  this.funcionarioForm.value.nome;
    this.funcionario.departamentos = this.funcionarioDepartamento;
    this.funService.registrarFuncionario(this.funcionario)
      .subscribe(result => {
        this.limparCampos();
        this.carrregarFuncionarios();
      });
  }
}
