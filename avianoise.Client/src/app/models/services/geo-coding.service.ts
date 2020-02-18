import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Address } from '../classes/address.class';


@Injectable({ providedIn: "root" })
export class GeoCodingService
{
	private apiUrl:string = 'api/geocoding';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	post(body : Address) : Observable<Address> {
		return this.http.post<Address>(this.apiUrl, body, this.options).pipe();
	}

}
