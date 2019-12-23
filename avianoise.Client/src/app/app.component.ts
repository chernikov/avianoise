import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';

import * as fromAppState from './state/app.state';
import * as fromAuthState from './state/auth.state';
import * as fromAuthActions from './state/auth.actions';
import { RoleService } from '@services/role.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(
    private store: Store<fromAppState.State>,
    private roleService: RoleService
  ) { }

  ngOnInit() {
    this.getTokenFromLS();
    this.getUserRole();
  }

  getTokenFromLS() {
    this.store.dispatch(
      new fromAuthActions.GetTokenFromLocalStorage()
    );
  }

  getUserRole() {
    this.store.pipe(select(fromAuthState.getUser)).subscribe(user => {
      if(user) {
        this.roleService.get(user.id).subscribe(res => {
          this.store.dispatch(
            new fromAuthActions.PopulateRole(res)
          );
        });
      }
    });
  }
}
