import { Component, OnInit } from '@angular/core';
import { Deposito } from '../../../core/models/deposito';
import { DepositService } from '../../../core/services/deposit/deposit.service';
import { Cuenta } from '../../../core/models/cuenta';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User, UserRegister } from 'src/app/core/models/usuario';
import { AuthService } from '../../../core/services/auth.service';
import { PostUserMoney } from 'src/app/core/models/postUserMoney';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.scss']
})
export class DepositComponent implements OnInit {

  cuenta:Cuenta;
  form: FormGroup;
  user:User


  constructor( private depositService:DepositService, private authService:AuthService, private formBuilder:FormBuilder ) { }

  async ngOnInit() {
    this.form = this.formBuilder.group({
      monto: new FormControl('',Validators.maxLength(50))
    });
    this.user = this.authService.getCurrentUser();
    this.cuenta =  (await this.depositService.getDeposit(this.user.id)).Object;
    

    console.log("this.cuenta")
    console.log(this.cuenta)
  }


  // async getDepositar(){
  //   this.cuenta =  (await this.depositService.getDeposit(this.user.id)).Object; 
  // }

  async postDepositar(){
    const postUserMoney: PostUserMoney = {UserAccountId: this.cuenta.Id, Amount: this.form.value.monto}
    const monto = this.form.value.monto

    if(monto>0){
      this.cuenta = (await this.depositService.postDeposit(postUserMoney)).Object;
      console.log("Escamea3")
    } else{
      console.log("Numero ingresado menor a 0")
      alert("Numero ingresado menor a 0")
    }
    
  }

}
