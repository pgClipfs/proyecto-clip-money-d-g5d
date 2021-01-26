import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PerfilService } from '../../core/services/perfil/perfil.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { User } from '../../core/models/usuario';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {
  
  userSesion:User;
  user:User;
  form: FormGroup;

  constructor(private router:Router,
              private perfilService :PerfilService,
              private authService:AuthService) { }

  async ngOnInit(){
    this.userSesion = this.authService.getCurrentUser();
    this.user = (await this.perfilService.getDatosUsuario(this.userSesion.Id)).Object
    
  }
  
  onEditarPerfil(){
    this.router.navigateByUrl("editar-perfil");
  }

}
