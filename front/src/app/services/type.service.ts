import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { Injectable } from "@angular/core";
import { IType } from '../models/IType';



@Injectable({
    providedIn: 'root'
})

export class TypeService {

    private environment = environment;
        
    private apiUrl = this.environment.apiUrl;
    
    constructor(private httpClient: HttpClient) {}

    getTypes() {
        const headers = new HttpHeaders({
            'Authorization': 'Basic ' + btoa('admin:password')
          });
          console.log('url api >>>>>>>>' + this.apiUrl + '/types');
        return this.httpClient.get<IType[]>(`${this.apiUrl}/types`, { headers });
    }

}