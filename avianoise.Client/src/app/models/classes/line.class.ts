import { Point } from './point.class';


export class Line {
	id : number;
	airportId : number;
	fileId : number;
	addedDate : string;
	level : number;
	published : boolean;
	points : Point[];

	constructor() {
		this.id = 0;
		this.airportId = 0;
		this.fileId = 0;
		this.addedDate = '';
		this.level = 0;
		this.published = false;
		this.points = [];
	}


}
