import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Result } from '../../models/result';
import { User, UserRegister } from '../../models/usuario';
import { EditarPerfil } from '../../models/editarPerfil';

@Injectable({
  providedIn: 'root'
})
export class EditPerfilService {

  constructor(private httpClient:HttpClient) { }
  
  async putEditPerfil (datosEditados: EditarPerfil){
    return await this.httpClient.put<Result<User>>(`${environment.apiUrl}/users`, datosEditados).toPromise();
  }
}


