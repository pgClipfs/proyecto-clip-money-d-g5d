import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User, UserRegister } from '../models/usuario';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  async login(user: UserRegister){
    return await this.http.post<string>(`${environment.apiUrl}/Auth/login`, user).toPromise();
  }

  setCurrentUser(token: string){
    localStorage.setItem('currentUser', token);
  }
}

