import { Component, OnInit } from '@angular/core';
import { Cuenta } from 'src/app/core/models/cuenta';
import { User } from 'src/app/core/models/usuario';
import { AuthService } from 'src/app/core/services/auth.service';
import { DepositService } from 'src/app/core/services/deposit/deposit.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  account: Cuenta;
  accounts: any;
  currentUser: User;
  constructor(private depositService: DepositService, private authService: AuthService) { }

  async ngOnInit(){
    this.currentUser = this.authService.getCurrentUser();
    this.account = (await this.depositService.getDeposit(this.currentUser.Id)).Object;

    this.accounts = [
      {
        amount: this.account.Amount,
        type: 'Pesos'
      },
      {
        amount: '0.0',
        type: 'U$D'
      }
    ];

  }



}
