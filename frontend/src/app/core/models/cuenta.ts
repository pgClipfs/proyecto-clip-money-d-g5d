import { Transferencia } from './transferencia';
import { Value } from './value';

export interface Cuenta {
    id: number;
    tipo: string;
    nombre: string;
    CBU: string;
    saldo: Value;
    transferencia: Transferencia[];
}