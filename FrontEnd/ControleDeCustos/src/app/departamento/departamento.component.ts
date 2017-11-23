import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { DepartamentoService } from '../services/departamento.service';
import { Departamento } from '../models/departamento';
import { Router } from '@angular/router';
import { NotificationService } from '../notificacao/notification.service';

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
              private router: Router,
              private notification: NotificationService) { }

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
    erros => {
      this.errorRequisicao(erros);
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
      },
      erros => {
        this.errorRequisicao(erros);
      });
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
