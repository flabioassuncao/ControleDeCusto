import { BrowserModule } from '@angular/platform-browser';
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

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FuncionarioComponent,
    DepartamentoComponent,
    MovimentacaoComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(ROUTES, {useHash: false})
  ],
  providers: [
    DepartamentoService,
    FuncionarioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
