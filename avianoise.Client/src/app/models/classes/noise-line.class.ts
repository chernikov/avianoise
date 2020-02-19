import { NoiseTypeEnum } from '../enums/noise-type-enum.enum';
import { DayNightTypeEnum } from '../enums/day-night-type-enum.enum';


export class NoiseLine {
	id : number;
	airportId : number;
	name : string;
	level : number;
	noiseType : NoiseTypeEnum[];
	dayNightType : DayNightTypeEnum[];

	constructor() {
		this.id = 0;
		this.airportId = 0;
		this.name = '';
		this.level = 0;
		this.noiseType = [];
		this.dayNightType = [];
	}


}
