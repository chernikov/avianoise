import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Practice } from '../classes/practice.class';


@Injectable({ providedIn: "root" })
export class PracticeService
{
	private apiUrl:string = 'api/practice';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	getAll(isPublished: boolean) : Observable<Practice[]> {
		return this.http.get<Practice[]>(this.apiUrl + "?" + "isPublished=" + isPublished, this.options).pipe();
	}

	post(body : Practice) : Observable<Practice> {
		return this.http.post<Practice>(this.apiUrl, body, this.options).pipe();
	}

	put(body : Practice) : Observable<Practice> {
		return this.http.put<Practice>(this.apiUrl, body, this.options).pipe();
	}

	get(id: number) : Observable<Practice> {
		return this.http.get<Practice>(this.apiUrl + "/" + id, this.options).pipe();
	}

	delete(practiceId: number) : Observable<null> {
		return this.http.delete<null>(this.apiUrl + "/" + practiceId, this.options).pipe();
	}

}
