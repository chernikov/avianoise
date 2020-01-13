import { Line } from './line.class';


export class File {
	id : number;
	airportId : number;
	isDecoded : boolean;
	fullPath : string;
	fileName : string;
	extension : string;
	content : string;
	lines : Line[];

	constructor() {
		this.id = 0;
		this.airportId = 0;
		this.isDecoded = false;
		this.fullPath = '';
		this.fileName = '';
		this.extension = '';
		this.content = '';
		this.lines = [];
	}


}
