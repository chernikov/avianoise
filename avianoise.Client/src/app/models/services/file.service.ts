import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { File } from '../classes/file.class';


@Injectable({ providedIn: "root" })
export class FileService
{
	private apiUrl:string = 'api/file';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	put(body : File) : Observable<File> {
		return this.http.put<File>(this.apiUrl, body, this.options).pipe();
	}

	delete(fileId: number) : Observable<null> {
		return this.http.delete<null>(this.apiUrl + "/" + fileId, this.options).pipe();
	}

}
