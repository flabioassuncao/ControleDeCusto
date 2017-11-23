import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { MovimentacaoComponent } from './movimentacao/movimentacao.component';
import { DepartamentoComponent } from './departamento/departamento.component';
import { AcessoComponent } from './acesso/acesso.component';
import { LoggedInGuard } from './acesso/loggedin.guard';

export const ROUTES: Routes = [
    {path: '', component: HomeComponent,
        canLoad: [LoggedInGuard], canActivate: [LoggedInGuard]},
    {path: 'home', component: HomeComponent,
        canLoad: [LoggedInGuard], canActivate: [LoggedInGuard]},
    {path: 'departamentos', component: DepartamentoComponent,
        canLoad: [LoggedInGuard], canActivate: [LoggedInGuard]},
    {path: 'funcionarios', component: FuncionarioComponent,
        canLoad: [LoggedInGuard], canActivate: [LoggedInGuard]},
    {path: 'movimentacoes', component: MovimentacaoComponent,
        canLoad: [LoggedInGuard], canActivate: [LoggedInGuard]},
    {path: 'acesso', component: AcessoComponent},
    {path: 'acesso/:to', component: AcessoComponent}
    // {path: '**', component: NotFoundComponent}
];
