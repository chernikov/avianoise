import { Injectable, OnDestroy } from "@angular/core";
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as airportsActions from './airports.actions';


import { map, mergeMap, last } from 'rxjs/operators';
import { AirportService } from '@services/airport.service';

@Injectable()
export class AirportsEffects {
    constructor(
        private actions$: Actions,
        private airportsService: AirportService
    ) { }

    @Effect()
    getAllAirports$: Observable<Action> = this.actions$.pipe(
        ofType(airportsActions.AirportsActionsTypes.GetAllAirports),
        mergeMap(action => {
            return this.airportsService.getAll().pipe(map(airports => 
                new airportsActions.GetAllAirportsSuccess(airports)
            ));
        })
    )

    @Effect()
    deleteAirport$: Observable<Action> = this.actions$.pipe(
        ofType(airportsActions.AirportsActionsTypes.DeleteAirport),
        mergeMap(action => {
            let airport = (action as airportsActions.DeleteAirport).payload;
            return this.airportsService.deleteAirport(airport.id).pipe(map(_ => 
                new airportsActions.GetAllAirports()
            ));
        })
    )
}