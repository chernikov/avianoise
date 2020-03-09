
export class Post {
	id : number;
	title : string;
	order : number;
	postId : number;
	text : string;
	isPublished : boolean;
	addedDate : string;
	posts : Post[];

	constructor() {
		this.id = 0;
		this.title = '';
		this.order = 0;
		this.postId = 0;
		this.text = '';
		this.isPublished = false;
		this.addedDate = '';
		this.posts = [];
	}


}
