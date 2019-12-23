export class User {
    id: number;
    name: string;
    email: string;
    roles: string[];

    constructor() {
        this.id = 0;
        this.name = '';
        this.email = '';
        this.roles = [];
    }
}