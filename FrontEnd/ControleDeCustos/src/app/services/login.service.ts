import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Router } from '@angular/router';
import { Usuario } from '../models/usuario';
import { CDC_API } from '../app.api';
import { error } from 'util';


@Injectable()
export class LoginService {

    usuario: Usuario;

    constructor(private http: HttpClient, private router: Router) {}

    isLoggedIn(): boolean {
        const token = localStorage.getItem('token_access');
        if (token === null) {
            return false;
        }
        return true;

        // this.verificarLogado(token).subscribe(
        //     x => {
        //         return true;
        //     },
        // response => {
        //     console.log(response);
        //      retunr false;
        // });
    }

    verificarLogado(token: any) {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        headers = headers.set('Authorization', `Bearer ${token}`);
        return this.http.get(`${CDC_API}/verificar-autenticacao`, {headers: headers})
        .catch(e => {
            console.log('catch');
            localStorage.clear();
            if (e.status === 401) {
                return Observable.throw('Unauthorized');
            }
        });
    }

    login(usuario: any): Observable<any> {
        return this.http.post<Usuario>(`${CDC_API}/login`, usuario);
    }

    cadastro(usuario: any): Observable<any> {
        return this.http.post<any>(`${CDC_API}/nova-conta`, usuario);
    }

    handleLogin(path?: string) {
        this.router.navigate(['/acesso', btoa(path)]);
    }
}
