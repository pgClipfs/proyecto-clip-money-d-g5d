import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form: FormGroup;

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  
  onEditarPerfil(){
    this.router.navigateByUrl("editar-perfil");
  }
}
