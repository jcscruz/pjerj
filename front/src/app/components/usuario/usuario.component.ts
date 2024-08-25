import { Component } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { CommonModule } from '@angular/common'; 
import { FormsModule } from '@angular/forms';
import { IUser } from '../../models/IUser';
import { IType } from '../../models/IType';
import { TypeService } from '../../services/type.service';

@Component({
  selector: 'app-usuario',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']  // Corrigido 'styleUrl' para 'styleUrls'
})
export class UsuarioComponent {
  btnText = "Cadastrar";
  usuarios: IUser[] = [];
  types: IType[] = [];

  selectedOption: string = '';
  options: string[] = []; 

  constructor(private usuarioService: UsuarioService, private typeService: TypeService) {
    this.getTypes();
  }

  onChange(event: any) {
    this.selectedOption = event.target.value.split(' - ')[0];
    this.getUsersByType(this.selectedOption);
  }

  getUsersByType(selectedOrigin:string) {
    this.usuarioService.getUsersByOrigin(selectedOrigin).subscribe((response) => {
      this.usuarios = response;
    });
  }

  getTypes() {
    this.typeService.getTypes().subscribe((response) => {
      this.types = response;
      // console.log('tipos===>' + response);
      // console.log(response);
      this.options = this.types.map(type => `${type.origin} - ${type.description}`);
    });
  }
}
