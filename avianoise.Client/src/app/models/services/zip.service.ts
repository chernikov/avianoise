import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BadRequestMessage } from '@classes/bad-request-message.class';
import { AirportZip } from '@classes/airport-zip.class';


@Injectable({ providedIn: "root" })
export class ZipService
{
	private apiUrl:string = 'api/';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(id: number) : Observable<AirportZip[]> {
        let url = this.apiUrl + 'airport/zip/' + id;
		return this.http.get<AirportZip[]>(url, this.options).pipe();
	}

    delete(id: number) : Observable<null> {
        let url = this.apiUrl + 'zip/' + id;
        return this.http.delete<null>(url, this.options).pipe();
    }

    unpack(id: number) : Observable<any> {
        let url = this.apiUrl + 'zip/unpack/' + id;
        return this.http.get<any>(url, this.options).pipe();
    }
}
