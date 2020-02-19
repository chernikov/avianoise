import { FeedbackFile } from './feedback-file.class';


export class Feedback {
	id : number;
	addedDate : string;
	name : string;
	email : string;
	message : string;
	feedbackFiles : FeedbackFile[];

	constructor() {
		this.id = 0;
		this.addedDate = '';
		this.name = '';
		this.email = '';
		this.message = '';
		this.feedbackFiles = [];
	}


}
