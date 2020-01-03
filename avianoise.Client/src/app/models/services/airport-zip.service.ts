import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Zip } from '../classes/zip.class';


@Injectable({ providedIn: "root" })
export class AirportZipService
{
	private apiUrl:string = 'api/airport/zip';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(airportId: number) : Observable<Zip[]> {
		return this.http.get<Zip[]>(this.apiUrl + "/" + airportId, this.options).pipe();
	}

	post(airportId: number) : Observable<Zip[]> {
		return this.http.post<Zip[]>(this.apiUrl + "/" + airportId, this.options).pipe();
	}

}
