import { Injectable } from "@angular/core";
import { CanLoad, CanActivate, CanActivateChild, Router } from '@angular/router';
import { Store, select } from '@ngrx/store';

import * as fromAppState from '../state/app.state';
import * as fromAuthState from '../state/auth.state';
import { Role } from '@classes/role.class';
import { Observable, of } from 'rxjs';
import { filter, take, switchMap, catchError, map, tap } from 'rxjs/operators';

@Injectable()
export class AuthorGuard implements CanActivate, CanActivateChild, CanLoad {
    constructor(
        private router: Router,
        private store: Store<fromAppState.State>
    ) { }

    canActivate(): Observable<boolean> {
        return this.process().pipe(
            switchMap(() => of(true)),
            catchError(() => {
                this.router.navigateByUrl('/registration');
                return of(false);
            })
        )
    }

    canActivateChild(): Observable<boolean> {
        return this.process().pipe(
            switchMap(() => of(true)),
            catchError(() => {
                this.router.navigateByUrl('/registration');
                return of(false);
            })
        )
    }

    canLoad(): Observable<boolean> {
        return this.process().pipe(
            switchMap(() => of(true)),
            catchError(() => {
                this.router.navigateByUrl('/registration');
                return of(false);
            })
        )
    }

    process(): Observable<any> {
        return this.store.pipe(
            select(fromAuthState.getUserRole),
            tap(p => p),
            filter((data: Role) => data.code === 'admin'),
            take(1)
        )
    }
}