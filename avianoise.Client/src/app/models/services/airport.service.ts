import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Airport } from '@classes/airport.class';
import { AirportForAdd } from '@classes/add-airport.class';
import { AirportForChange } from '@classes/change-airport.class';

@Injectable({ providedIn: 'root' })
export class AirportService {
    private apiUrl: string = 'api/airport';
    private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
    };
    
    constructor(private http: HttpClient) { }

    addAirport(body: AirportForAdd): Observable<Airport> {
        return this.http.post<Airport>(this.apiUrl, body, this.options).pipe();
    }

    getAirport(id: number): Observable<Airport> {
        return this.http.get<Airport>(this.apiUrl + '/' + id, this.options).pipe();
    } 

    getAll(): Observable<Airport[]> {
        return this.http.get<Airport[]>(this.apiUrl, this.options).pipe();
    }

    changeAirport(body: AirportForChange): Observable<Airport> {
        return this.http.put<Airport>(this.apiUrl + '/', body, this.options).pipe();
    }

    deleteAirport(id: number): Observable<null> {
        return this.http.delete<null>(this.apiUrl + '/' + id, this.options).pipe();
    }
}