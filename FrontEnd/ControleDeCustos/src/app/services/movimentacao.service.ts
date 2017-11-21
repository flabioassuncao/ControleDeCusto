import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { CDC_API } from '../app.api';
import { Movimentacao } from '../models/movimentacao';

@Injectable()
export class MovimentacaoService {

    constructor(private http: HttpClient) {}

    movimentacaoes(): Observable<Movimentacao[]> {
        return this.http.get<Movimentacao[]>(`${CDC_API}/obter-todas-movimentacoes`);
    }

    movimentacaoesFiltradas(funcionarioId: string, descricao: string): Observable<Movimentacao[]> {
        const endpoint = 'obter-movimentacao-por-filtro';
        return this.http.get<Movimentacao[]>(`${CDC_API}/${endpoint}?idFuncionario=${funcionarioId}&descricao=${descricao}`);
    }

    registrarMovimentacao(movimentacao: Movimentacao): Observable<any> {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');

        return this.http.post(`${CDC_API}/adicionar-movimentacao`, movimentacao, { headers: headers });
    }
}
