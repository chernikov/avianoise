import { Injectable, Inject } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { JwtHelperService } from '@auth0/angular-jwt';

import * as authActions from './auth.actions';

import { LOCAL_STORAGE } from '@ng-toolkit/universal';
import { Observable, of } from 'rxjs';
import { Action } from '@ngrx/store';
import { map, catchError, switchMap, partition, mergeMap, last } from 'rxjs/operators';
import { applicationOptions } from '../config/options';

@Injectable()
export class AuthEffects {
    constructor(@Inject(LOCAL_STORAGE) private localStorage: any,
        private jwtHelperService: JwtHelperService,
        private actions$: Actions
    ) { }

    @Effect()
    loadToken$: Observable<Action> = this.actions$.pipe(
        ofType(authActions.AuthActionTypes.GetTokenFromLocalStorage),
        mergeMap(_ => {
            let token = this.localStorage.getItem(applicationOptions.authTokenName);
            if(token && !this.jwtHelperService.isTokenExpired(token)) {
                let obj = this.jwtHelperService.decodeToken(token);
                let user = JSON.parse(obj.user)
                return of(
                    new authActions.LoadTokenFromLocalStorageSuccess(token),
                    new authActions.PopulateUser(user)
                );
            } else {
                return of(new authActions.ClearAuthStorage());
            }
        }),
        catchError(err => of(new authActions.LoadTokenFromLocalStorageFail(err)))
    );

    @Effect()
    saveToken$: Observable<Action> = this.actions$.pipe(
        ofType(authActions.AuthActionTypes.SaveTokenToLocalStorage),
        map(action => {
            let token = (action as authActions.SaveTokenToLocalStorage).payload;
            if(token && !this.jwtHelperService.isTokenExpired(token)) {
                this.localStorage.setItem(applicationOptions.authTokenName, token);
                let obj = this.jwtHelperService.decodeToken(token);
                let user = JSON.parse(obj.user);
                return new authActions.PopulateUser(user);
            } else {
                return new authActions.ClearAuthStorage();
            }
        }),
        catchError(err => of(new authActions.LoadTokenFromLocalStorageFail(err)))
    )

    @Effect()
    clearToken$: Observable<Action> = this.actions$.pipe(
        ofType(authActions.AuthActionTypes.ClearAuthStorage),
        last(action => {
            this.localStorage.setItem(applicationOptions.authTokenName, null);
            return null;
        }),
        catchError(err => of(new authActions.LoadTokenFromLocalStorageFail(err)))
    );
}