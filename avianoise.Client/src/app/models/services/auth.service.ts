import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Login } from '../classes/login.class';
import { Token } from '../classes/token.class';
import { BadRequestMessage } from '../classes/bad-request-message.class';


@Injectable({ providedIn: "root" })
export class AuthService
{
	private apiUrl:string = 'api/auth';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	post(body : Login) : Observable<Token> {
		return this.http.post<Token>(this.apiUrl, body, this.options).pipe();
	}

}
