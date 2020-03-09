import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Post } from '../classes/post.class';


@Injectable({ providedIn: "root" })
export class PostOrderService
{
	private apiUrl:string = 'api/post-order';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	post(body : Post[]) : Observable<Post[]> {
		return this.http.post<Post[]>(this.apiUrl, body, this.options).pipe();
	}

}
