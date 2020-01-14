import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { File } from '../classes/file.class';


@Injectable({ providedIn: "root" })
export class FileClearService
{
	private apiUrl:string = 'api/file/clear';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(fileId: number) : Observable<File> {
		return this.http.get<File>(this.apiUrl + "/" + fileId, this.options).pipe();
	}

}
