import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './presentation/login/login.component';
import { DepositComponent } from './presentation/shared/deposit/deposit.component';
import { TransferComponent } from './presentation/shared/transfer/transfer.component';
import { MovementsComponent } from './presentation/shared/movements/movements.component';

const routes: Routes = [
  { path: '',   redirectTo: '/login', pathMatch: 'full' },
  { path: 'home', loadChildren: () => import('./presentation/home/home.module').then(m => m.HomeModule) },
  { path: 'login', component:LoginComponent},
  { path: 'deposit', component:DepositComponent},
  { path: 'transfer', component:TransferComponent},
  { path: 'movements', component:MovementsComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
