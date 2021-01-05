import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cuenta } from '../../models/cuenta';
import { UserToken } from '../../models/userToken.model';
import { environment } from 'src/environments/environment';
import { Result } from '../../models/result';
import { PostUserMoney } from '../../models/postUserMoney';


@Injectable({
  providedIn: 'root'
})
export class DepositService {

  constructor(private http:HttpClient) { }

  //get de cuenta y post de cuenta
  //Depositar dinero
  async getDeposit (userId: number){
    return await this.http.get<Result<Cuenta>>(`${environment.apiUrl}/account/${userId}`).toPromise();
  }

  async postDeposit( postUserMoney:PostUserMoney ){
    return await this.http.post<Result<Cuenta>>(`${environment.apiUrl}/account`, postUserMoney).toPromise();
  }

  //Extraer dinero

  async getExtract (userId: number){
    return await this.http.get<Result<Cuenta>>(`${environment.apiUrl}/account/${userId}`).toPromise();
  }

  async postExtract( postUserMoney:PostUserMoney ){
    return await this.http.post<Result<Cuenta>>(`${environment.apiUrl}/account`, postUserMoney).toPromise();
  }

}
