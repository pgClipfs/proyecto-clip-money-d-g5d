import { Value } from './value';

export interface Transferencia {
    id: number;
    tipo: string;
    idFrom: string;
    idTo: string;
    date: Date;
    value: Value;
    referencia: number;
}