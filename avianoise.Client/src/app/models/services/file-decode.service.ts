import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { ExtendedFile } from '../classes/extended-file.class';


@Injectable({ providedIn: "root" })
export class FileDecodeService
{
	private apiUrl:string = 'api/file/decode';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(fileId: number,force: boolean) : Observable<ExtendedFile> {
		return this.http.get<ExtendedFile>(this.apiUrl + "/" + fileId + "?" + "force=" + force, this.options).pipe();
	}

}
