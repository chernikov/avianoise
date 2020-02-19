import { Line } from './line.class';
import { NoiseTypeEnum } from '../enums/noise-type-enum.enum';
import { DayNightTypeEnum } from '../enums/day-night-type-enum.enum';
import { TimeTypeEnum } from '../enums/time-type-enum.enum';


export class ExtendedFile {
	lines : Line[];
	id : number;
	airportId : number;
	isDecoded : boolean;
	fullPath : string;
	fileName : string;
	extension : string;
	noiseType : NoiseTypeEnum;
	dayNightType : DayNightTypeEnum;
	timeType : TimeTypeEnum;

	constructor() {
		this.lines = [];
		this.id = 0;
		this.airportId = 0;
		this.isDecoded = false;
		this.fullPath = '';
		this.fileName = '';
		this.extension = '';
		this.noiseType = 0;
		this.dayNightType = 0;
		this.timeType = 0;
	}


}
