import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Airport } from '../classes/airport.class';


@Injectable({ providedIn: "root" })
export class AirportPublishedService
{
	private apiUrl:string = 'api/airport/published';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get() : Observable<Airport[]> {
		return this.http.get<Airport[]>(this.apiUrl, this.options).pipe();
	}

}
