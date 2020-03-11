import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Practice } from '../classes/practice.class';


@Injectable({ providedIn: "root" })
export class PracticeOrderService
{
	private apiUrl:string = 'api/practice-order';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	post(body : Practice[]) : Observable<Practice[]> {
		return this.http.post<Practice[]>(this.apiUrl, body, this.options).pipe();
	}

}
