import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { PostFile } from '../classes/post-file.class';


@Injectable({ providedIn: "root" })
export class PostFileService
{
	private apiUrl:string = 'api/post-file';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get() : Observable<PostFile[]> {
		return this.http.get<PostFile[]>(this.apiUrl, this.options).pipe();
	}

	post() : Observable<PostFile> {
		return this.http.post<PostFile>(this.apiUrl, this.options).pipe();
	}

	delete(id: number) : Observable<null> {
		return this.http.delete<null>(this.apiUrl + "/" + id, this.options).pipe();
	}

}
