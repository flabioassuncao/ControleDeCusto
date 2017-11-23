import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { DepartamentoService } from '../services/departamento.service';
import { Departamento } from '../models/departamento';
import { Router } from '@angular/router';

@Component({
  selector: 'app-departamento',
  templateUrl: './departamento.component.html'
})
export class DepartamentoComponent implements OnInit {

  departamentoForm: FormGroup;
  departamentos: Departamento[];
  departamento: Departamento;

  constructor(private depService: DepartamentoService,
              private formBuilder: FormBuilder,
              private router: Router) { }

  ngOnInit() {
    this.carrregarDepartamentos();

    this.departamentoForm = this.formBuilder.group({
      nome: this.formBuilder.control('', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]),
    });
  }

  carrregarDepartamentos() {
    this.depService.departamentos().subscribe(departamentos => {
      this.departamentos = departamentos;
    },
    reponse => {
      localStorage.clear();
      this.router.navigate(['/acesso']);
    });
  }

  limparCampos() {
    this.departamentoForm.reset();
  }

  registrarDepartamento() {
    const depart = Object.assign({}, this.departamento, this.departamentoForm.value);
    this.depService.registrarDepartamento(depart)
      .subscribe(result => {
        this.limparCampos();
        this.carrregarDepartamentos();
      });
  }

}
