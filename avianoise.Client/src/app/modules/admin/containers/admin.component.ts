import { Component, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';

import * as fromRoot from '@state/app.state';
import * as fromAuthActions from '@state/auth/auth.actions';
import * as fromAirportsActions from '@state/airports/airports.actions';
import * as fromAirportsState from '@state/airports/airports.state';
import { Router } from '@angular/router';
import { Airport } from '@classes/airport.class';

import { untilDestroyed } from 'ngx-take-until-destroy';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnDestroy {
  
  airports: Airport[];

  constructor(
    private store: Store<fromRoot.State>,
    private router: Router
  ) {
    this.airports = [];
    
    this.store.pipe(select(fromAirportsState.getAirports), 
      untilDestroyed(this))
      .subscribe(airports => {
      this.airports = airports;
    });

    this.store.dispatch(new fromAirportsActions.GetAllAirports());
  }

  deleteAirport(airport: Airport) {
    this.store.dispatch(
      new fromAirportsActions.DeleteAirport(airport)
    );
  }

  onLogout() {
    this.store.dispatch(
      new fromAuthActions.ClearAuthStorage()
    );
    this.router.navigateByUrl('login');
  }

  ngOnDestroy() {
    //need for untilDestroyed
  }
}
