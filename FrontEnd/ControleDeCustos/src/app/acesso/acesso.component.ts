import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../services/login.service';

import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { NotificationService } from '../notificacao/notification.service';

@Component({
  selector: 'app-acesso',
  templateUrl: './acesso.component.html'
})
export class AcessoComponent implements OnInit {

  cadastroForm: FormGroup;
  loginForm: FormGroup;
  navigateTo: string;

  constructor(private formBuilder: FormBuilder,
              private activatedRoute: ActivatedRoute,
              private loginService: LoginService,
              private router: Router,
              private notification: NotificationService) {
  }

  ngOnInit() {

    this.loginForm = this.formBuilder.group({
      email: this.formBuilder.control('', [Validators.required, Validators.email]),
      senha: this.formBuilder.control('', [Validators.required, Validators.minLength(6), Validators.maxLength(16)])
    });

    this.cadastroForm = this.formBuilder.group({
      email: this.formBuilder.control('', [Validators.required, Validators.email]),
      senha: this.formBuilder.control('', [Validators.required, Validators.minLength(6), Validators.maxLength(16)]),
      confirmarSenha: this.formBuilder.control('', [Validators.required, Validators.minLength(6), Validators.maxLength(16)])
    }, {validator: this.equalsTo});
    this.navigateTo = this.activatedRoute.snapshot.params['to'] || btoa('/');
  }


  // tslint:disable-next-line:member-ordering
  equalsTo(group: AbstractControl) {
    const senha = group.get('senha');
    const confirmarSenha = group.get('confirmarSenha');
    if (!senha || !confirmarSenha) {
      return undefined;
    }
    if (senha.value !== confirmarSenha.value) {
      return {passwordsNotMatch: true};
    }
    return undefined;
  }

  cadastrarUsuario() {
    const usuario = Object.assign({}, this.cadastroForm.value);
    this.loginService.cadastro(usuario).subscribe(response => {
      this.notification.notify(`Usuário cadastrado com sucesso!`);
      this.setLocalStorage(response);
      this.router.navigate([ atob(this.navigateTo)]);
    },
    error => {
      this.notification.notify(`Erro ao realizar cadastro, tente novamente!`);
    });
  }

  login() {
    const usuario = Object.assign({}, this.loginForm.value);
    this.loginService.login(usuario).subscribe(response => {
      this.setLocalStorage(response);
      this.notification.notify(`Login realizado com sucesso!`);
      this.router.navigate([ atob(this.navigateTo)]);
    },
    error => {
      this.notification.notify(`Erro ao realizar login, tente novamente!`);
    });
  }

  setLocalStorage(response: any) {
    localStorage.setItem('token_access', response.data.result.access_token);
    localStorage.setItem('user_cdc', JSON.stringify(response.data.result.user));
  }

}
