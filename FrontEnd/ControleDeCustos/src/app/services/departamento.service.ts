import { Injectable } from '@angular/core';
import { Departamento } from '../models/departamento';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { CDC_API } from '../app.api';
import 'rxjs/add/operator/catch';

@Injectable()
export class DepartamentoService {

    constructor(private http: HttpClient) { }

    departamentos(): Observable<Departamento[]> {
        const token = localStorage.getItem('token_access');
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        headers = headers.set('Authorization', `Bearer ${token}`);

        return this.http.get<Departamento[]>(`${CDC_API}/obter-todos-departamentos`, {headers: headers});
    }

    registrarDepartamento(departamento: Departamento): Observable<any> {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        const token = localStorage.getItem('token_access');
        headers = headers.set('Authorization', `Bearer ${token}`);

        return this.http.post(`${CDC_API}/adicionar-departamento`, departamento, { headers: headers });
    }
}
