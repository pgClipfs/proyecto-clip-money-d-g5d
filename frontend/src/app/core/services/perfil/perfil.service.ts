import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Result } from '../../models/result';
import { environment } from 'src/environments/environment';
import { User } from '../../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private http:HttpClient) { }

  async getDatosUsuario (userId: number){
    return await this.http.get<Result<User>>(`${environment.apiUrl}/users/${userId}`).toPromise();
  }
}
