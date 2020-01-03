import { Line } from './line.class';


export class File {
	id : number;
	airportId : number;
	fullPath : string;
	fileName : string;
	extension : string;
	content : string;
	lines : Line[];

	constructor() {
		this.id = 0;
		this.airportId = 0;
		this.fullPath = '';
		this.fileName = '';
		this.extension = '';
		this.content = '';
		this.lines = [];
	}


}
