import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Line } from '../classes/line.class';


@Injectable({ providedIn: "root" })
export class LineService
{
	private apiUrl:string = 'api/line';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	get(lineId: number) : Observable<Line> {
		return this.http.get<Line>(this.apiUrl + "/" + lineId, this.options).pipe();
	}

	delete(lineId: number) : Observable<null> {
		return this.http.delete<null>(this.apiUrl + "/" + lineId, this.options).pipe();
	}

	put(body : Line) : Observable<Line> {
		return this.http.put<Line>(this.apiUrl, body, this.options).pipe();
	}

}
