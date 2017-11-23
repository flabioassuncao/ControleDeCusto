import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { CDC_API } from '../app.api';
import { Funcionario } from '../models/funcionario';

@Injectable()
export class FuncionarioService {

    constructor(private http: HttpClient) { }

    funcionarios(): Observable<Funcionario[]> {
        const token = localStorage.getItem('token_access');
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        headers = headers.set('Authorization', `Bearer ${token}`);

        return this.http.get<Funcionario[]>(`${CDC_API}/obter-todos-funcionarios`, {headers: headers});
    }

    registrarFuncionario(funcionario: Funcionario): Observable<any> {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        const token = localStorage.getItem('token_access');
        headers = headers.set('Authorization', `Bearer ${token}`);

        return this.http.post(`${CDC_API}/adicionar-funcionario`, funcionario, { headers: headers });
    }
}
