import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User, UserRegister } from '../models/usuario';
import { HttpClient } from '@angular/common/http';
import { UserToken } from '../models/userToken.model';
import jwt_decode from 'jwt-decode';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  async login(user: UserRegister){
    return await this.http.post<UserToken>(`${environment.apiUrl}/Auth/login`, user).toPromise();
  }

  setCurrentUser(token: string){
    localStorage.setItem('currentUser', token);
  }

  getCurrentUser(){
    const token = this.getToken();
    if (token !== null){

      const tokenDecode = jwt_decode(token);

      const currentUser: User = {
        id: parseInt(tokenDecode['nameid'], 10),
        mail: tokenDecode['email'],
        Firstname: tokenDecode['firstname']
      };
      return currentUser;
    }
  }

  getToken(){
    return localStorage.getItem('currentUser');
  }
}

