import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private URL: string = "http://localhost:8882/";

  constructor(private _http: HttpClient) { }

  /**
   * login()
   * Retorna un observable que compara el usuario y contraseña
   * que recibe con las de prueba, si estas coinciden, se completa en 1,5s.
   * Los setTimeout son para simular el delay de la peticion
   */
  login(user: any) {
    return this._http.post<any>(this.URL+'login', user)
  }
}
