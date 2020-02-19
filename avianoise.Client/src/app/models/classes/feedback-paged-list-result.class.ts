import { Feedback } from './feedback.class';


export class FeedbackPagedListResult {
	items : Feedback[];
	totalPages : number;

	constructor() {
		this.items = [];
		this.totalPages = 0;
	}


}
