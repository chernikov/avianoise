import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AirportService } from '@services/airport.service';
import { AirportPost } from '@classes/airport.post.class';
import { MouseEvent } from '@agm/core';
import { untilDestroyed } from 'ngx-take-until-destroy';
import * as fromRoot from '@state/app.state';
import * as fromAirportsActions from '@state/airports/airports.actions';

@Component({
  selector: 'app-add-airport',
  templateUrl: './add-airport.component.html',
  styleUrls: ['./add-airport.component.scss']
})
export class AddAirportComponent implements OnInit, OnDestroy {
  airport: AirportPost;

  latitude: number;
  longitude: number;
  zoom:number;

  markerCreateAnimation: string;
  markersInitAnimation: string = 'DROP';

  form: FormGroup;

  constructor(
    private store: Store<fromRoot.State>,
    private formBuilder: FormBuilder,
    private airportService: AirportService
  ) {
    this.airport = new AirportPost();
    this.setCurrentLocation();
    this.initForm();
  }

  ngOnInit() {
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
    let airport: AirportPost = {
      lat: this.airport.lat,
      lng: this.airport.lng,
      name: this.form.value.name
    }

    this.airportService.addAirport(airport).pipe(untilDestroyed(this)).subscribe(airport => {
      if(airport) {
        this.form.reset();
        this.airport = new AirportPost();
        this.store.dispatch(new fromAirportsActions.GetAllAirports());
      }
    })
  }

  ngOnDestroy() {
    //need for untilDestroyed
  }

}
