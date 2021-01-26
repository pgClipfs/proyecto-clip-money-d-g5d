import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { User } from '../../../core/models/usuario';
import { GiroDescubiertoService } from '../../../core/services/giro-descubierto/giro-descubierto.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-giro-descubierto',
  templateUrl: './giro-descubierto.component.html',
  styleUrls: ['./giro-descubierto.component.scss']
})
export class GiroDescubiertoComponent implements OnInit {

  cuenta:User;
  userId
  giroDescubierto: User

  constructor(private authService: AuthService,
              private giroDescubiertoService : GiroDescubiertoService,
              private router: Router) { }

  async ngOnInit() {

    //lo utilizamos para traer los datos de sesion de dicho usuario
    this.cuenta = this.authService.getCurrentUser();
    console.log("this.cuenta")
    console.log(this.cuenta)

    //devuelve la cuenta del usuario
    this.userId = (await this.giroDescubiertoService.GetCuentaUsuario(this.cuenta.Id)).Object
    console.log("this.userId")
    console.log(this.userId)
  }

  async onGiroDescubierto(){
    const result = await this.giroDescubiertoService.GetGiroDescubierto(this.userId.Id);
    this.giroDescubierto = (result).Object
    if(result.Ok){
      window.alert('Giro asignado con éxito!');
      this.router.navigateByUrl('/home');
    }else{
      window.alert(result.ErrorsText);
      this.router.navigateByUrl('/home');
    }

    console.log("this.giroDescubierto")
    console.log(this.giroDescubierto)
  }

}
