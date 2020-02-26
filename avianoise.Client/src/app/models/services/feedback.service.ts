import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { FeedbackPagedListResult } from '../classes/feedback-paged-list-result.class';
import { Feedback } from '../classes/feedback.class';


@Injectable({ providedIn: "root" })
export class FeedbackService
{
	private apiUrl:string = 'api/feedback';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(page: number) : Observable<FeedbackPagedListResult> {
		return this.http.get<FeedbackPagedListResult>(this.apiUrl + "?" + "page=" + page, this.options).pipe();
	}

	post(body : Feedback) : Observable<Feedback> {
		return this.http.post<Feedback>(this.apiUrl, body, this.options).pipe();
	}

	delete(id: number,all: boolean) : Observable<null> {
		return this.http.delete<null>(this.apiUrl + "?" + "id=" + id + "&" + "all=" + all, this.options).pipe();
	}

}
