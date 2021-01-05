import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Cuenta } from 'src/app/core/models/cuenta';
import { PostUserMoney } from 'src/app/core/models/postUserMoney';
import { User } from 'src/app/core/models/usuario';
import { AuthService } from 'src/app/core/services/auth.service';
import { TransferService } from '../../../core/services/transfer/transfer.service';
import { Transferencia } from '../../../core/models/transferencia';
import { PostTransfer } from 'src/app/core/models/PostTransfer';

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

  constructor( private transferService:TransferService, private authService:AuthService, private formBuilder:FormBuilder) { }

  async ngOnInit() {
    this.form = this.formBuilder.group({
      monto: new FormControl('',Validators.maxLength(50))
    });
    this.user = this.authService.getCurrentUser();
    this.cuenta =  (await this.transferService.getTransfer(this.user.transferencias)).Object;
    

    console.log("this.cuenta")
    console.log(this.cuenta)
  }
  

  async postTransferir(){
    const postTransfer: PostTransfer = {IdInboundAccount: this.cuenta.Id, IdOutboundAccount: this.cuenta.Id, Amount: this.form.value.monto}
    const monto = this.form.value.monto
    

    this.cuenta = (await this.transferService.postTransfer(postTransfer)).Object;
        
  }
}
