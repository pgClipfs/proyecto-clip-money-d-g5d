import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Result } from '../../models/result';
import { Cuenta } from '../../models/cuenta';
import { environment } from 'src/environments/environment';
import { User } from '../../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class GiroDescubiertoService {

  constructor(private httpClient: HttpClient) { }


  async GetGiroDescubierto (AccountId: number){
    return await this.httpClient.get<Result<Cuenta>>(`${environment.apiUrl}/Account/overdraft/${AccountId}`)  .toPromise();
  }

  async GetCuentaUsuario (userId: number){
    return await this.httpClient.get<Result<User>>(`${environment.apiUrl}/Account/${userId}`).toPromise();
  }

}
