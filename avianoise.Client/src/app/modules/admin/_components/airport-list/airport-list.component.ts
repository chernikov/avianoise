import { Component } from '@angular/core';
import { select, Store } from '@ngrx/store';

import * as fromRoot from '@state/app.state';
import * as fromAirportsActions from '@state/airports/airports.actions';
import * as fromAirportsState from '@state/airports/airports.state';

import { Airport } from '@classes/airport.class';

@Component({
  selector: 'app-airport-list',
  templateUrl: './airport-list.component.html',
  styleUrls: ['./airport-list.component.scss']
})
export class AirportListComponent {
  airports: Airport[];
  test: any;

  constructor(
    private store: Store<fromRoot.State>
  ) {
    this.airports = [];
    
    this.store.pipe(select(fromAirportsState.getAirports))
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
}
