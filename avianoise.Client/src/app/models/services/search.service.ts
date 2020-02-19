import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { LocationResult } from '../classes/location-result.class';


@Injectable({ providedIn: "root" })
export class SearchService
{
	private apiUrl:string = 'api/search';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(searchString: string) : Observable<LocationResult> {
		return this.http.get<LocationResult>(this.apiUrl + "?" + "searchString=" + searchString, this.options).pipe();
	}

}
