import { Component, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MouseEvent } from '@agm/core';

import { Store } from '@ngrx/store';
import * as fromRoot from '@state/app.state';
import * as fromAirportsActions from '@state/airports/airports.actions';

import { AirportService } from '@services/airport.service';
import { ActivatedRoute, Router } from '@angular/router';
import { takeWhile } from 'rxjs/operators';
import { Airport } from '@classes/airport.class';

@Component({
  selector: 'app-edit-airport',
  templateUrl: './edit-airport.component.html',
  styleUrls: ['./edit-airport.component.scss']
})
export class EditAirportComponent implements OnDestroy {
  alive: boolean = true;
  isEdit: boolean = false;

  airport: Airport;

  latitude: number = 48.383022;
  longitude: number = 31.1828699;
  zoom: number = 6;

  markerCreateAnimation: string;
  markersInitAnimation: string = 'DROP';

  form: FormGroup;
  constructor(
    private store: Store<fromRoot.State>,
    private formBuilder: FormBuilder,
    private airportService: AirportService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.airport = new Airport();
    this.setCurrentLocation();
    this.initForm();
    this.getAirport();
  }

  getAirport() {
    this.route.params.subscribe(param => {
      if(param.id) {
        this.airportService.get(param.id).pipe(takeWhile(() => this.alive)).subscribe(airport => {
          this.airport = airport;
          this.isEdit = true;
          this.form.setValue({
            name: airport.name
          });
          this.latitude = airport.lat;
          this.longitude = airport.lng;
        });
      }
    });
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
    let airport: Airport = {
      id: 0,
      lat: this.airport.lat,
      lng: this.airport.lng,
      name: this.form.value.name,
      files: [],
      lines: [],
      zips: []
    };
    if(this.isEdit) {
      airport.id = this.airport.id;
      airport.files = this.airport.files;
      airport.zips = this.airport.zips;
      this.airportService.put(airport).pipe(takeWhile(() => this.alive)).subscribe(airport => {
        this.store.dispatch(new fromAirportsActions.GetAllAirports());
        this.router.navigateByUrl('/admin/airport');
      });
    } else {
      this.airportService.post(airport).pipe(takeWhile(() => this.alive)).subscribe(airport => {
        if(airport) {
          this.store.dispatch(new fromAirportsActions.GetAllAirports());
          this.router.navigateByUrl('/admin/airport');
        }
      });
    }
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
