import { Action } from '@ngrx/store';
import { Airport } from '@classes/airport.class';

export enum AirportsActionsTypes {
    GetAllAirports = '[Airports] Get all airports',
    GetAllAirportsSuccess = '[Airports] Get airports success',
    AddAirport = '[Airports] Add airport',
    ChangeAirport = '[Airports] Change airport',
    DeleteAirport = '[Airports] Delete airport',
}

export class GetAllAirports implements Action {
    readonly type = AirportsActionsTypes.GetAllAirports;
}

export class GetAllAirportsSuccess implements Action {
    readonly type = AirportsActionsTypes.GetAllAirportsSuccess;
    constructor(public payload: Airport[]) { }
}

export class AddAirport implements Action {
    readonly type = AirportsActionsTypes.AddAirport;
    constructor(public payload: Airport) { }
}

export class ChangeAirport implements Action {
    readonly type = AirportsActionsTypes.ChangeAirport;
    constructor(public payload: Airport) { }
}

export class DeleteAirport implements Action {
    readonly type = AirportsActionsTypes.DeleteAirport;
    constructor(public payload: Airport) { }
}

export type AirportActions = 
    GetAllAirports |
    GetAllAirportsSuccess |
    AddAirport |
    ChangeAirport |
    DeleteAirport;