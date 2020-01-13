import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { File } from '../classes/file.class';


@Injectable({ providedIn: "root" })
export class AirportFileService
{
	private apiUrl:string = 'api/airport/file';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(airportId: number, onlyDecoded: boolean) : Observable<File[]> {
		return this.http.get<File[]>(this.apiUrl + "/" + airportId + "?onlyDecoded=" + onlyDecoded, this.options).pipe();
	}

	post(airportId: number) : Observable<File[]> {
		return this.http.post<File[]>(this.apiUrl + "/" + airportId, this.options).pipe();
	}

}
