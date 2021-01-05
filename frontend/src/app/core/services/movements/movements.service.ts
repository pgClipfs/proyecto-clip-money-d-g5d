import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Result } from '../../models/result';
import { Movements } from '../../models/movements';

@Injectable({
  providedIn: 'root'
})
export class MovementsService {

  constructor( private httpClient:HttpClient) { }

  async getMovements (AccountId: number){
    return await this.httpClient.get<Result<Movements[]>>(`${environment.apiUrl}/movement/${AccountId}`).toPromise();
  }
}
