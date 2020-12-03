import { Contacto } from './contacto';
import { Cuenta } from './cuenta';
import { Transferencia } from './transferencia';

export interface User {
    id: number;
    nombre: string;
    apellido: string;
    mail: string;
    dni: number;
    cuentas: Cuenta[];
    contactos: Contacto[];
    transferencias: Transferencia[];
    password: string;
}

export interface UserRegister{
  Email: string;
  Password: string;
}
