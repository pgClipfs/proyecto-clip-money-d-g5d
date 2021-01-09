import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User, UserRegister } from '../../models/usuario';
import { UserToken } from '../../models/userToken.model';
import { Result } from '../../models/result';

@Injectable({
  providedIn: 'root'
})
export class SingInService {

  constructor(private httpClient:HttpClient) { }

  async register(user:User){
    return await this.httpClient.post<User>(`${environment.apiUrl}/auth/sign-in`, user).toPromise();
  }

}
