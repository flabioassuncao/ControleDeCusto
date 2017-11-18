import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { MovimentacaoComponent } from './movimentacao/movimentacao.component';
import { DepartamentoComponent } from './departamento/departamento.component';

export const ROUTES: Routes = [
    {path: '', component: HomeComponent},
    {path: 'departamentos', component: DepartamentoComponent},
    {path: 'funcionarios', component: FuncionarioComponent},
    {path: 'movimentacoes', component: MovimentacaoComponent}
    // {path: '**', component: NotFoundComponent}
];
