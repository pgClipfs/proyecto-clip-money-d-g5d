import { Value } from './value';

export interface Transferencia {
    Id: number;
    Tipo?: string;
    IdInboundAccount: number;
    IdOutboundAccount: number;
    Date?: Date;
    Amount: number;
    Referencia?: number;
}