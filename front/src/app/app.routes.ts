import { Routes } from '@angular/router';
import { UsuarioComponent } from './components/usuario/usuario.component';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
    { path: 'usuario', component: UsuarioComponent },
    { path: '', component: HomeComponent },
];
