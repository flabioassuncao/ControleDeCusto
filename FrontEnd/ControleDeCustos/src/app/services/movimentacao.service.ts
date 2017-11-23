import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { CDC_API } from '../app.api';
import { Movimentacao } from '../models/movimentacao';

@Injectable()
export class MovimentacaoService {

    constructor(private http: HttpClient) {}

    movimentacaoes(): Observable<Movimentacao[]> {
        const token = localStorage.getItem('token_access');
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        headers = headers.set('Authorization', `Bearer ${token}`);
        return this.http.get<Movimentacao[]>(`${CDC_API}/obter-todas-movimentacoes`, {headers: headers});
    }

    movimentacaoesFiltradas(funcionarioId: string, descricao: string): Observable<Movimentacao[]> {
        const token = localStorage.getItem('token_access');
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        headers = headers.set('Authorization', `Bearer ${token}`);

        const endpoint = `obter-movimentacao-por-filtro?idFuncionario=${funcionarioId}&descricao=${descricao}`;
        return this.http.get<Movimentacao[]>(`${CDC_API}/${endpoint}`, {headers: headers});
    }

    registrarMovimentacao(movimentacao: Movimentacao): Observable<any> {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        const token = localStorage.getItem('token_access');
        headers = headers.set('Authorization', `Bearer ${token}`);

        return this.http.post(`${CDC_API}/adicionar-movimentacao`, movimentacao, { headers: headers });
    }
}
