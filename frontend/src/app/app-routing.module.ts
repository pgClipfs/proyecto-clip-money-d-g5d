import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './presentation/login/login.component';
import { DepositComponent } from './presentation/shared/deposit/deposit.component';
import { TransferComponent } from './presentation/shared/transfer/transfer.component';
import { MovementsComponent } from './presentation/shared/movements/movements.component';
import { SignInComponent } from './presentation/shared/sign-in/sign-in.component';
import { PerfilComponent } from './presentation/perfil/perfil.component';
import { PerfilEditComponent } from './presentation/perfil-edit/perfil-edit.component';

const routes: Routes = [
  { path: '',   redirectTo: '/login', pathMatch: 'full' },
  { path: 'home', loadChildren: () => import('./presentation/home/home.module').then(m => m.HomeModule) },
  { path: 'login', component:LoginComponent},
  { path: 'deposit', component:DepositComponent},
  { path: 'transfer', component:TransferComponent},
  { path: 'movements', component:MovementsComponent},
  { path: 'sign-in', component:SignInComponent},
  { path: 'perfil', component:PerfilComponent},
  { path: 'editar-perfil', component:PerfilEditComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
