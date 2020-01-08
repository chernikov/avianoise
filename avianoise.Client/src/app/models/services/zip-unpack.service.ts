import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { File } from '../classes/file.class';


@Injectable({ providedIn: "root" })
export class ZipUnpackService
{
	private apiUrl:string = 'api/zip/unpack';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(zipId: number) : Observable<File[]> {
		return this.http.get<File[]>(this.apiUrl + "/" + zipId, this.options).pipe();
	}

}
