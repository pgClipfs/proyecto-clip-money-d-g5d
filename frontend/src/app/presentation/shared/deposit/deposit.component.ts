import { Component, OnInit } from '@angular/core';
import { Deposito } from '../../../core/models/deposito';
import { DepositService } from '../../../core/services/deposit/deposit.service';
import { Cuenta } from '../../../core/models/cuenta';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User, UserRegister } from 'src/app/core/models/usuario';
import { AuthService } from '../../../core/services/auth.service';
import { PostUserMoney } from 'src/app/core/models/postUserMoney';
import { Router } from '@angular/router';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.scss']
})
export class DepositComponent implements OnInit {

  cuenta:Cuenta;
  form: FormGroup;
  user:User
  isSubmitted: boolean = false;
  showTransaction= false;

  constructor(private depositService:DepositService,
              private authService:AuthService,
              private formBuilder:FormBuilder,
              private router: Router) { }

  async ngOnInit() {
    this.form = this.formBuilder.group({
      monto: new FormControl('',[Validators.maxLength(50), Validators.required])
    });
    this.user = this.authService.getCurrentUser();
    this.cuenta =  (await this.depositService.getDeposit(this.user.Id)).Object;

  }

  goto(){
    this.router.navigateByUrl('/home');
  }

  async postDepositar(){
    this.isSubmitted = true;
    if(this.form.valid){
      this.showTransaction = true;
      const postUserMoney: PostUserMoney = {UserAccountId: this.cuenta.Id, Amount: this.form.value.monto}
      this.cuenta = (await this.depositService.postDeposit(postUserMoney)).Object;

    }
  }

  async postExtraer(){
    this.isSubmitted = true;
    if(this.form.valid){
      const postUserMoney: PostUserMoney = {UserAccountId: this.cuenta.Id, Amount: this.form.value.monto * -1}
      if(this.cuenta.Amount + postUserMoney.Amount < 0){
        alert('No cuenta con saldo suficiente para realizar la extracción');
      }else{
        this.cuenta = (await this.depositService.postDeposit(postUserMoney)).Object;
        this.showTransaction = true;
      }
    }
  }

}
