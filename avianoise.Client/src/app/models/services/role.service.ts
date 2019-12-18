import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


import { Role } from '@classes/role.class';


@Injectable({ providedIn: "root" })
export class RoleService
{
	private apiUrl:string = 'api/role';

	private headers = new HttpHeaders({
		"content-type": "application/json",
		"Accept": "application/json"
	});
	private options = {
		headers : this.headers
	};

	constructor(private http: HttpClient) {}

	getAll() : Observable<Role[]> {
		return this.http.get<Role[]>(this.apiUrl, this.options).pipe();
	}

	get(id: number) : Observable<Role> {
		return this.http.get<Role>(this.apiUrl + "/" + id, this.options).pipe();
	}

}
