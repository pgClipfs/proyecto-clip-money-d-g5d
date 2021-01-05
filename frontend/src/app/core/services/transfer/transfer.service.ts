import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Cuenta } from '../../models/cuenta';
import { PostTransfer } from '../../models/PostTransfer';
import { Result } from '../../models/result';
import { Transferencia } from '../../models/transferencia';
import { User } from '../../models/usuario';



@Injectable({
  providedIn: 'root'
})
export class TransferService {

  constructor(private httpClient: HttpClient) { }

  //Transferencia
  // async getTransfer (transfer: Transferencia){
  //   return await this.httpClient.get<Result<Cuenta>>(`${environment.apiUrl}/transfer/${transfer.IdOutboundAccount}&${transfer.IdInboundAccount}`).toPromise();
  // }

  async postTransfer( postTransfer:PostTransfer ){
    return await this.httpClient.post<Result<Cuenta>>(`${environment.apiUrl}/transfer`, postTransfer).toPromise();
  }
}
