import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { DepartamentoComponent } from './departamento/departamento.component';
import { MovimentacaoComponent } from './movimentacao/movimentacao.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { ROUTES } from './app.routes';
import { DepartamentoService } from './services/departamento.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FuncionarioService } from './services/funcionario.service';
import { MovimentacaoService } from './services/movimentacao.service';
import { AcessoComponent } from './acesso/acesso.component';
import { LoginService } from './services/login.service';
import { LoggedInGuard } from './acesso/loggedin.guard';

import {ToastModule} from 'ng2-toastr/ng2-toastr';
import { NotificacaoComponent } from './notificacao/notificacao.component';
import { NotificationService } from './notificacao/notification.service';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FuncionarioComponent,
    DepartamentoComponent,
    MovimentacaoComponent,
    HomeComponent,
    AcessoComponent,
    NotificacaoComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToastModule.forRoot(),
    RouterModule.forRoot(ROUTES, {useHash: false})
  ],
  providers: [
    DepartamentoService,
    FuncionarioService,
    MovimentacaoService,
    LoginService,
    NotificationService,
    LoggedInGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
