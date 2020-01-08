import { Component } from '@angular/core';
import { Store } from '@ngrx/store';

import * as fromRoot from '@state/app.state';
import * as fromAuthActions from '@state/auth/auth.actions';
import { Router } from '@angular/router';
import { NbMenuItem } from '@nebular/theme';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  menu: NbMenuItem[];
  constructor(
    private store: Store<fromRoot.State>,
    private router: Router
  ) {
    this.menu = [
      {
        title: 'Airports',
        link: '/admin/airport/',
        icon: 'home-outline'
      }
    ]
  }

  onLogout() {
    this.store.dispatch(
      new fromAuthActions.ClearAuthStorage()
    );
    this.router.navigateByUrl('login');
  }
}
