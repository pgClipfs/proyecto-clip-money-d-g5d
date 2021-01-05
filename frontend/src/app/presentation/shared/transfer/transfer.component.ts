import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Cuenta } from 'src/app/core/models/cuenta';
import { PostUserMoney } from 'src/app/core/models/postUserMoney';
import { User } from 'src/app/core/models/usuario';
import { AuthService } from 'src/app/core/services/auth.service';
import { TransferService } from '../../../core/services/transfer/transfer.service';
import { Transferencia } from '../../../core/models/transferencia';
import { PostTransfer } from 'src/app/core/models/PostTransfer';
import { DepositService } from 'src/app/core/services/deposit/deposit.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-transfer',
  templateUrl: './transfer.component.html',
  styles: [
  ]
})
export class TransferComponent implements OnInit {

  cuenta:Cuenta;
  form: FormGroup;
  user:User

  constructor( private transferService:TransferService, private authService:AuthService, private formBuilder:FormBuilder
              , private depositService: DepositService, private router: Router) { }

  async ngOnInit() {
    this.form = this.formBuilder.group({
      monto: new FormControl('',Validators.maxLength(50)),
      cuentaSaliente: new FormControl('',Validators.maxLength(10)),
      cuentaEntrante: new FormControl('',Validators.maxLength(10))
    });
    this.user = this.authService.getCurrentUser();
    this.cuenta =  (await this.depositService.getDeposit(this.user.id)).Object;
  }
  

  async postTransferir(){
    const postTransfer: PostTransfer = {IdOutboundAccount: this.cuenta.Id, 
                                        IdInboundAccount: this.form.value.cuentaEntrante,
                                        Amount: this.form.value.monto};
    const monto = this.form.value.monto;
    const cuentaEntrante = this.form.value.cuentaEntrante;  

    this.cuenta = (await this.transferService.postTransfer(postTransfer)).Object
  
    alert("La transacción se realizó correctamente!")

    this.router.navigateByUrl('/home');


    // this.transferService.postTransfer( this.cuenta.Id)
    // console.log("this.form.value.cuentaSaliente")
    // console.log(this.form.value.cuentaSaliente)
    // console.log("this.form.value.monto")
    // console.log(this.form.value.monto)
    // console.log("this.cuenta")
    // console.log(this.cuenta)
    // console.log("Entró al método postTransferir")
  }
}
