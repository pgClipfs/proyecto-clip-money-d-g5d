import { Transferencia } from './transferencia';
import { Value } from './value';

export interface Cuenta {
    UserId: number;
    CreationDate: Date;
    CreationTime: Date;
    TypeAccountId: string;
    amount: number;
    Movements: Transferencia[];
    CurrencyTypeId: any; //Falta agregar el model de tipoCuenta
    CryptocurrencyId: any; //Falta agregar el model de crypto
}