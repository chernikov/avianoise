import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';



@Injectable({ providedIn: "root" })
export class ZipService
{
	private apiUrl:string = 'api/zip';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	delete(zipId: number) : Observable<null> {
		return this.http.delete<null>(this.apiUrl + "/" + zipId, this.options).pipe();
	}

}
