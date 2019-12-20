export class AirportZip {
    id: number;
    airportId: number;
    addedDate: Date;
    filePath: string;

    constructor() {
        this.id = 0;
        this.airportId = 0;
        this.addedDate = new Date();
        this.filePath = '';
    }
}