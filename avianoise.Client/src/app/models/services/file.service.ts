import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BadRequestMessage } from '@classes/bad-request-message.class';
import { File } from '@classes/file.class';
import { Line } from '@classes/line.class';


@Injectable({ providedIn: "root" })
export class FileService
{
	private apiUrl:string = 'api/airport/file/';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(id: number) : Observable<File[]> {
        let url = this.apiUrl + id;
		return this.http.get<File[]>(url, this.options).pipe();
    }

    decode(id: number) : Observable<Line[]> {
        let url = 'api/file/decode/' + id;
        return this.http.get<Line[]>(url, this.options).pipe();
    }

    delete(id: number) : Observable<null> {
        let url = 'api/file/' + id;
        return this.http.delete<null>(url, this.options).pipe();
    }
}
