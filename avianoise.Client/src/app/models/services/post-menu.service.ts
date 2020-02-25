import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Post } from '../classes/post.class';


@Injectable({ providedIn: "root" })
export class PostMenuService
{
	private apiUrl:string = 'api/post-menu';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get() : Observable<Post[]> {
		return this.http.get<Post[]>(this.apiUrl, this.options).pipe();
	}

}
