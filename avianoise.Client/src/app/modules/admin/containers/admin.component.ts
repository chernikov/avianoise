import { Component } from '@angular/core';
import { Store } from '@ngrx/store';

import * as fromRoot from '@state/app.state';
import * as fromAuthActions from '@state/auth/auth.actions';
import { Router } from '@angular/router';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  constructor(
    private store: Store<fromRoot.State>,
    private router: Router
  ) { }

  onLogout() {
    this.store.dispatch(
      new fromAuthActions.ClearAuthStorage()
    );
    this.router.navigateByUrl('login');
  }
}
