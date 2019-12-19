import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import * as fromRoot from '../../../state/app.state';
import * as fromAuthActions from '../../../state/auth.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  constructor(
    private store: Store<fromRoot.State>,
    private router: Router
  ) { }

  ngOnInit() {
  }

  onLogout() {
    this.store.dispatch(
      new fromAuthActions.ClearAuthStorage()
    );
    this.router.navigateByUrl('registration');
  }
}
