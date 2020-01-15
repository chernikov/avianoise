import { ExtendedFile } from './extended-file.class';
import { Line } from './line.class';
import { Zip } from './zip.class';


export class Airport {
	id : number;
	name : string;
	lat : number;
	lng : number;
	files : ExtendedFile[];
	lines : Line[];
	zips : Zip[];

	constructor() {
		this.id = 0;
		this.name = '';
		this.lat = 0;
		this.lng = 0;
		this.files = [];
		this.lines = [];
		this.zips = [];
	}


}
