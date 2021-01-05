import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './presentation/login/login.component';
import { DepositComponent } from './presentation/shared/deposit/deposit.component';

const routes: Routes = [
  { path: '',   redirectTo: '/login', pathMatch: 'full' },
  { path: 'home', loadChildren: () => import('./presentation/home/home.module').then(m => m.HomeModule) },
  { path: 'login', component:LoginComponent},
  { path: 'deposit', component:DepositComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
