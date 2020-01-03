import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BadRequestMessage } from '@classes/bad-request-message.class';
import { Line } from '@classes/line.class';


@Injectable({ providedIn: "root" })
export class LineService
{
	private apiUrl:string = 'api/line/';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

    constructor(private http: HttpClient) {}
    
    getAll(airportId: number) : Observable<Line[]> {
        let url = 'api/airport/line/' + airportId;
        return this.http.get<Line[]>(url, this.options).pipe();
    }

	get(id: number) : Observable<Line> {
        let url = this.apiUrl + id;
		return this.http.get<Line>(url, this.options).pipe();
    }

    change(body: Line) : Observable<Line> {
        let url = this.apiUrl;
        return this.http.put<Line>(url, body, this.options).pipe();
    }

    delete(id: number) : Observable<null> {
        let url = this.apiUrl + id;
        return this.http.delete<null>(url, this.options).pipe();
    }
}
