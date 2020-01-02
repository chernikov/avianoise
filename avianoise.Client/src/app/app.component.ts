import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';

import * as fromAppState from '@state/app.state';
import * as fromAuthState from '@state/auth/auth.state';
import * as fromAuthActions from '@state/auth/auth.actions';
import { RoleService } from '@services/role.service';
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnDestroy {
  title = 'app';
  alive: boolean = true;

  constructor(
    private store: Store<fromAppState.State>,
    private roleService: RoleService
  ) {
    this.getTokenFromLS();
    this.getUserRole();
  }

  getTokenFromLS() {
    this.store.dispatch(
      new fromAuthActions.GetTokenFromLocalStorage()
    );
  }

  getUserRole() {
    this.store.pipe(select(fromAuthState.getUser), takeWhile(() => this.alive)).subscribe(user => {
      if(user) {
        this.roleService.get(user.id).subscribe(res => {
          this.store.dispatch(
            new fromAuthActions.PopulateRole(res)
          );
        });
      }
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
