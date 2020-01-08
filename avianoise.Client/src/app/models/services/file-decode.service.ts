import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Line } from '../classes/line.class';


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

	get(fileId: number) : Observable<Line[]> {
		return this.http.get<Line[]>(this.apiUrl + "/" + fileId, this.options).pipe();
	}

}
