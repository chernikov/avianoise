import { Component, OnDestroy } from '@angular/core';
import { MouseEvent } from '@agm/core';
import { Store } from '@ngrx/store';

import * as fromRoot from '../../../state/app.state';
import * as fromAuthActions from '../../../state/auth.actions';
import { Router } from '@angular/router';
import { Airport } from '@classes/airport.class';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AirportService } from '@services/airport.service';
import { AirportPost } from '@classes/airport.post.class';

import { takeWhile } from 'rxjs/operators';
import { untilDestroyed } from 'ngx-take-until-destroy';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnDestroy {
  latitude: number;
  longitude: number;
  zoom:number;

  markerCreateAnimation: string;
  markersInitAnimation: string = 'DROP';

  airport: AirportPost;
  airports: Airport[];

  form: FormGroup;

  constructor(
    private store: Store<fromRoot.State>,
    private router: Router,
    private formBuilder: FormBuilder,
    private airportService: AirportService
  ) {
    this.airports = [];
    this.airport = new AirportPost();
    this.initForm();
    this.setCurrentLocation();
    this.getAirports();
  }

  initForm() {
    this.form = this.formBuilder.group({
      name: [null, Validators.required]
    });
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

  getAirports() {
    this.airportService.getAll().pipe(untilDestroyed(this)).subscribe(airports => {
      if(airports) this.airports = airports;
    });
  }

  createMarker(event: MouseEvent) {
    this.markerCreateAnimation = 'BOUNCE';
    this.airport.lat = event.coords.lat;
    this.airport.lng = event.coords.lng;
    setTimeout(() => {
      this.markerCreateAnimation = null;
    }, 500);
  }

  markerDragEnd(event: MouseEvent) {
    this.airport.lat = event.coords.lat;
    this.airport.lng = event.coords.lng;
  }

  saveAirport() {
    let airport: AirportPost = {
      lat: this.airport.lat,
      lng: this.airport.lng,
      name: this.form.value.name
    }

    this.airportService.addAirport(airport).pipe(untilDestroyed(this)).subscribe(airport => {
      if(airport) {
        this.form.reset();
        this.airport = new AirportPost();
        this.airports.push(airport);
      }
    })
  }

  onLogout() {
    this.store.dispatch(
      new fromAuthActions.ClearAuthStorage()
    );
    this.router.navigateByUrl('login');
  }

  ngOnDestroy() { }
}
