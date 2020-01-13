import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Token } from '../classes/token.class';


@Injectable({ providedIn: "root" })
export class TokenService
{
	private apiUrl:string = 'api/token';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get() : Observable<Token> {
		return this.http.get<Token>(this.apiUrl, this.options).pipe();
	}

}
