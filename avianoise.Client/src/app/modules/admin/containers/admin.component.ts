import { Component, OnInit } from '@angular/core';
import { MouseEvent } from '@agm/core';
import { Store } from '@ngrx/store';

import * as fromRoot from '../../../state/app.state';
import * as fromAuthActions from '../../../state/auth.actions';
import { Router } from '@angular/router';
import { Airport } from '@classes/airport.class';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  latitude: number;
  longitude: number;
  zoom:number;
  airports: Airport[];

  constructor(
    private store: Store<fromRoot.State>,
    private router: Router
  ) {
    this.airports = [];
  }

  ngOnInit() {
      this.setCurrentLocation();
  }

  onLogout() {
    this.store.dispatch(
      new fromAuthActions.ClearAuthStorage()
    );
    this.router.navigateByUrl('login');
  }

  private setCurrentLocation() {
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.latitude = position.coords.latitude;
        this.longitude = position.coords.longitude;
        this.zoom = 8;
      });
    }
  }

  airportDragEnd(airport: Airport, event: MouseEvent) {
    this.latitude = event.coords.lat;
    this.longitude = event.coords.lng;
  }

  addAirport(event: MouseEvent) {
    let airport: Airport = {
      id: this.airports.length + 1,
      name: 'Some Airport',
      lat: event.coords.lat,
      lng: event.coords.lng,
      zips: []
    };
    this.airports.push(airport);
  }

  onAirportRightClick(airport: Airport) {
    this.airports = this.airports.filter(item => item.id != airport.id);
  }
}
