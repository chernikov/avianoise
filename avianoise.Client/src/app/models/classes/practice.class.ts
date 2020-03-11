
export class Practice {
	id : number;
	title : string;
	order : number;
	practiceId : number;
	text : string;
	isPublished : boolean;
	addedDate : string;
	practices : Practice[];

	constructor() {
		this.id = 0;
		this.title = '';
		this.order = 0;
		this.practiceId = 0;
		this.text = '';
		this.isPublished = false;
		this.addedDate = '';
		this.practices = [];
	}


}
