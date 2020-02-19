import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { FeedbackFile } from '../classes/feedback-file.class';


@Injectable({ providedIn: "root" })
export class FeedbackFileService
{
	private apiUrl:string = 'api/feedback-file';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	post() : Observable<FeedbackFile[]> {
		return this.http.post<FeedbackFile[]>(this.apiUrl, this.options).pipe();
	}

}
