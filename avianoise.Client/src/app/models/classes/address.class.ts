
export class Address {
	id : number;
	searchLine : string;
	addressJson : string;
	lat : number;
	lng : number;
	addedDate : string;

	constructor() {
		this.id = 0;
		this.searchLine = '';
		this.addressJson = '';
		this.lat = 0;
		this.lng = 0;
		this.addedDate = '';
	}


}
