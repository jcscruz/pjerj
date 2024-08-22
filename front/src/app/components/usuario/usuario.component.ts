import { Component } from '@angular/core';
import { UsuarioFormComponent } from "../usuario-form/usuario-form.component";

@Component({
  selector: 'app-usuario',
  standalone: true,
  imports: [UsuarioFormComponent],
  templateUrl: './usuario.component.html',
  styleUrl: './usuario.component.css'
})
export class UsuarioComponent {
  btnText = "Cadastrar"
}
