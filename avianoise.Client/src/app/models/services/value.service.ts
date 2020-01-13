import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';



@Injectable({ providedIn: "root" })
export class ValueService
{
	private apiUrl:string = 'api/value';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get() : Observable<null> {
		return this.http.get<null>(this.apiUrl, this.options).pipe();
	}

}
