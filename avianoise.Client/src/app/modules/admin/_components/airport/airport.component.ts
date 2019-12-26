import { Component, OnInit, OnDestroy } from '@angular/core';
import { select, Store } from '@ngrx/store';

import * as fromRoot from '@state/app.state';
import * as fromAirportsActions from '@state/airports/airports.actions';
import * as fromAirportsState from '@state/airports/airports.state';

import { Airport } from '@classes/airport.class';
import { ActivatedRoute } from '@angular/router';
import { AirportService } from '@services/airport.service';
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'app-airport',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.scss']
})
export class AirportComponent implements OnInit, OnDestroy {
  alive: boolean = true;
  airport: Airport;
  airportIsLoad: boolean; 
  constructor(
    private store: Store<fromRoot.State>,
    private route: ActivatedRoute,
    private airportService: AirportService
  ) {
    this.airportIsLoad = false;
  }

  ngOnInit() {
    this.getAirport();
  }

  getAirport() {
    this.route.params.subscribe(param => {
      this.airportService.getAirport(param.id).pipe(takeWhile(() => this.alive)).subscribe(airport => {
        if(airport) {
          this.airport = airport;
          this.airportIsLoad = true;
        }
      });
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
