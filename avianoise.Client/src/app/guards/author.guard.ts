import { Injectable } from "@angular/core";
import { CanLoad, CanActivate, CanActivateChild, Router } from '@angular/router';
import { Store, select } from '@ngrx/store';

import * as fromAppState from '../state/app.state';
import * as fromAuthState from '../state/auth.state';
import { Role } from '@classes/role.class';

@Injectable()
export class AuthorGuard implements CanLoad, CanActivate, CanActivateChild {
    role: Role;

    constructor(
        private router: Router,
        private store: Store<fromAppState.State>
    ) {
        this.store.pipe(select(fromAuthState.getUserRole)).subscribe(role => {
            this.role = role
        });
    }

    canLoad(): boolean {
        return this.process();
    }

    canActivate(): boolean {
        return this.process();
    }

    canActivateChild(): boolean {
        return this.process();
    }

    process(): boolean {
        if(this.role) {
            let role = this.role.code;
        
            if(role != 'admin') {
                this.router.navigateByUrl('index');
            }
            return true;
        } else return false;

    }
}