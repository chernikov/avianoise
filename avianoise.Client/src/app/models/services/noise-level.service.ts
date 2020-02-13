import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { NoiseLine } from '../classes/noise-line.class';


@Injectable({ providedIn: "root" })
export class NoiseLevelService
{
	private apiUrl:string = 'api/noise-level';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(lat: number,lng: number) : Observable<NoiseLine[]> {
		return this.http.get<NoiseLine[]>(this.apiUrl + "?" + "lat=" + lat + "&" + "lng=" + lng, this.options).pipe();
	}

}
