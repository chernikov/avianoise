import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { ExtendedFile } from '../classes/extended-file.class';


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

	get(airportId: number,onlyDecoded: boolean) : Observable<ExtendedFile[]> {
		return this.http.get<ExtendedFile[]>(this.apiUrl + "/" + airportId + "?onlyDecoded=" + onlyDecoded, this.options).pipe();
	}

	post(airportId: number) : Observable<ExtendedFile[]> {
		return this.http.post<ExtendedFile[]>(this.apiUrl + "/" + airportId, this.options).pipe();
	}

}
