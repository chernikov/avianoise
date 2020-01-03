import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Airport } from '../classes/airport.class';


@Injectable({ providedIn: "root" })
export class AirportService
{
	private apiUrl:string = 'api/airport';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	getAll() : Observable<Airport[]> {
		return this.http.get<Airport[]>(this.apiUrl, this.options).pipe();
	}

	post(body : Airport) : Observable<Airport> {
		return this.http.post<Airport>(this.apiUrl, body, this.options).pipe();
	}

	put(body : Airport) : Observable<Airport> {
		return this.http.put<Airport>(this.apiUrl, body, this.options).pipe();
	}

	get(airportId: number) : Observable<Airport> {
		return this.http.get<Airport>(this.apiUrl + "/" + airportId, this.options).pipe();
	}

	delete(airportId: number) : Observable<null> {
		return this.http.delete<null>(this.apiUrl + "/" + airportId, this.options).pipe();
	}

}
