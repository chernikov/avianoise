import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Line } from '../classes/line.class';


@Injectable({ providedIn: "root" })
export class AirportLineService
{
	private apiUrl:string = 'api/airport/line';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(airportId: number) : Observable<Line[]> {
		return this.http.get<Line[]>(this.apiUrl + "/" + airportId, this.options).pipe();
	}

}
