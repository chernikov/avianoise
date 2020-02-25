
export class Post {
	id : number;
	title : string;
	text : string;
	isPublished : boolean;
	addedDate : string;

	constructor() {
		this.id = 0;
		this.title = '';
		this.text = '';
		this.isPublished = false;
		this.addedDate = '';
	}


}
