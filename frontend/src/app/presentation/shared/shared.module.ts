import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionComponent } from './transaction/transaction.component';
import { MainHeaderComponent } from './main-header/main-header.component';
// import { MovementsComponent } from './movements/movements.component';
// import { DepositComponent } from './deposit/deposit.component';
// import { TransferComponent } from './transfer/transfer.component';



@NgModule({
  declarations: [TransactionComponent, MainHeaderComponent],
  imports: [
    CommonModule
  ],
  exports: [TransactionComponent, MainHeaderComponent]
})
export class SharedModule { }
