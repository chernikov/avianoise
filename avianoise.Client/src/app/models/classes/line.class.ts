import { Point } from '@classes/point.class';

export class Line {
    id: number;
    airportId: number;
    fileId: number;
    addedDate: Date;
    level: number;
    published: boolean;
    points: Point[]
    constructor() {
        this.id = 0;
        this.airportId = 0;
        this.fileId = 0;
        this.addedDate = new Date();
        this.level = 0;
        this.published = false;
        this.points = [];
    }
}