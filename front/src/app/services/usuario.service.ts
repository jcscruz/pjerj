import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { Injectable } from "@angular/core";
import { IUser } from '../models/IUser';


@Injectable({
    providedIn: 'root'
})

export class UsuarioService {

    private environment = environment;
        
    private apiUrl = this.environment.apiUrl;
    
    constructor(private httpClient: HttpClient) { }

    obterUsuarios() {
        const headers = new HttpHeaders({
            'Authorization': 'Basic ' + btoa('admin:password')
          });
        return this.httpClient.get<IUser[]>(`${this.apiUrl}/users`, { headers });
    }

    getUsersByOrigin(origin: string){
        const headers = new HttpHeaders({
            'Authorization': 'Basic ' + btoa('admin:password')
          });
        console.log(`url api >>>>>>>>${this.apiUrl}/users?origin=${origin}`)
        return this.httpClient.get<IUser[]>(`${this.apiUrl}/users?origin=${origin}`, { headers });
    }

}