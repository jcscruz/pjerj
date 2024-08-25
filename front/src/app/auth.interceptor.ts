// auth.interceptor.ts
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const username = 'admin'; // Substitua pelo seu nome de usuário
    const password = 'password'; // Substitua pela sua senha
    const authHeader = 'Basic ' + btoa('admin:password');

    const authReq = req.clone({
      setHeaders: {
        Authorization: authHeader
      }
    });
    return next.handle(authReq);
  }
}
