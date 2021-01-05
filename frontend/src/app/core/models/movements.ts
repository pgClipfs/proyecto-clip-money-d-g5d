import { User } from "./usuario";

export class Movements{
    Id: number;
    AccountId : number;
    DestinationAccountId : number;
    Amount : number;
    MovementId : number;
    MovementName: string;
    User: User;
    UserDestination: User;

}