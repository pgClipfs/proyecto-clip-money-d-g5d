import { Component, OnInit } from '@angular/core';
import { Cuenta } from 'src/app/core/models/cuenta';
import { User } from 'src/app/core/models/usuario';
import { AuthService } from 'src/app/core/services/auth.service';
import { DepositService } from 'src/app/core/services/deposit/deposit.service';
import { Movements } from '../../../core/models/movements';
import { MovementsService } from '../../../core/services/movements/movements.service';

@Component({
  selector: 'app-movements',
  templateUrl: './movements.component.html',
  styles: [
  ]
})
export class MovementsComponent implements OnInit {

  movimiento: Movements[] = [];
  user:User;
  cuenta:Cuenta;

  constructor(private movementsService :MovementsService,
              private depositService:DepositService,
              private authService:AuthService ) { }

  async ngOnInit(){
    this.user = this.authService.getCurrentUser();
    this.cuenta =  (await this.depositService.getDeposit(this.user.Id)).Object;
    this.movimiento = (await this.movementsService.getMovements(this.cuenta.Id)).Object
    

    console.log("this.cuenta");
    console.log(this.cuenta);
    console.log("this.movimiento");
    console.log(this.movimiento);
    
  }

  // async mostrarMovimiento(movimiento: Movements[]){
  //     this.movimiento = (await this.movementsService.getMovements(this.cuenta.Id)).Object
  // }

}
