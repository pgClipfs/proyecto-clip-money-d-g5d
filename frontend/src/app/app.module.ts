import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { ApplicationModule } from './application/application.module';
import { SharedModule } from './presentation/shared/shared.module';
import { LoginComponent } from './presentation/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DepositComponent} from './presentation/shared/deposit/deposit.component'
import { TransferComponent } from './presentation/shared/transfer/transfer.component';
import { MovementsComponent } from './presentation/shared/movements/movements.component';
import { SignInComponent } from './presentation/shared/sign-in/sign-in.component';
import { PerfilComponent } from './presentation/perfil/perfil.component';
import { PerfilEditComponent } from './presentation/perfil-edit/perfil-edit.component';
import { GiroDescubiertoComponent } from './presentation/shared/giro-descubierto/giro-descubierto.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DepositComponent,
    TransferComponent,
    MovementsComponent,
    SignInComponent,
    PerfilComponent,
    PerfilEditComponent,
    GiroDescubiertoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    CoreModule,
    ApplicationModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
