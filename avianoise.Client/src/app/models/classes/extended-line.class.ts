import { File } from './file.class';
import { Point } from './point.class';


export class ExtendedLine {
	file : File[];
	id : number;
	airportId : number;
	fileId : number;
	addedDate : string;
	name : string;
	level : number;
	published : boolean;
	points : Point[];

	constructor() {
		this.file = [];
		this.id = 0;
		this.airportId = 0;
		this.fileId = 0;
		this.addedDate = '';
		this.name = '';
		this.level = 0;
		this.published = false;
		this.points = [];
	}


}
