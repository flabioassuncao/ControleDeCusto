import { Injectable } from '@angular/core';
import { Departamento } from '../models/departamento';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { CDC_API } from '../app.api';

@Injectable()
export class DepartamentoService {

    constructor(private http: HttpClient) {}

    departamentos(): Observable<Departamento[]> {
        return this.http.get<Departamento[]>(`${CDC_API}/obter-todos-departamentos`);
    }

      registrarDepartamento(departamento: Departamento): Observable<any> {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');

        return this.http.post(`${CDC_API}/adicionar-departamento`, departamento, { headers: headers });
    }
}
