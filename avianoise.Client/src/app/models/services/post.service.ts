import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Post } from '../classes/post.class';


@Injectable({ providedIn: "root" })
export class PostService
{
	private apiUrl:string = 'api/post';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	getAll(isPublished: boolean) : Observable<Post[]> {
		return this.http.get<Post[]>(this.apiUrl + "?" + "isPublished=" + isPublished, this.options).pipe();
	}

	post(body : Post) : Observable<Post> {
		return this.http.post<Post>(this.apiUrl, body, this.options).pipe();
	}

	put(body : Post) : Observable<Post> {
		return this.http.put<Post>(this.apiUrl, body, this.options).pipe();
	}

	get(id: number) : Observable<Post> {
		return this.http.get<Post>(this.apiUrl + "/" + id, this.options).pipe();
	}

	delete(postId: number) : Observable<null> {
		return this.http.delete<null>(this.apiUrl + "/" + postId, this.options).pipe();
	}

}
