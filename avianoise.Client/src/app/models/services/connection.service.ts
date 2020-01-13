import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';



@Injectable({ providedIn: "root" })
export class ConnectionService
{
	private apiUrl:string = 'api/connection';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	post(body : string) : Observable<null> {
		return this.http.post<null>(this.apiUrl, body, this.options).pipe();
	}

}
