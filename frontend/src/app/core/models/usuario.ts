import { Contacto } from './contacto';
import { Cuenta } from './cuenta';
import { Transferencia } from './transferencia';

export interface User {
    Id?: number;
    Firstname?: string;
    Lastname?: string;
    Email?: string;
    Dni?: number;
    cuentas?: Cuenta[];
    contactos?: Contacto[];
    transferencias?: Transferencia;
    Password?: string;
    Cbu?: number;
}

export interface UserRegister{
  Email: string;
  Password: string;
}
