import { AirportZip } from '@classes/airport-zip.class';

export class Airport {
    id: number;
    name: string;
    lat: number;
    lng: number;
    zips: AirportZip[];

    constructor() {
        this.id = 0;
        this.name = '';
        this.lat = 0;
        this.lng = 0;
        this.zips = [];
    }
}