/// <reference types="@types/googlemaps" />
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';

import { IfSlideAnimation } from '@animations';

import { AgmCoreModule, AgmMap, GoogleMapsAPIWrapper } from '@agm/core';
import { GoogleMap } from '@agm/core/services/google-maps-types';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss'],
  animations: [
    IfSlideAnimation
  ]
})
export class MapComponent implements OnInit, AfterViewInit {

  isKadastrLayer: boolean = false;

  @ViewChild('gmap', { static: true }) gmapElement: any;

  map: google.maps.Map;

  EXTENT = [-Math.PI * 6378137, Math.PI * 6378137];

  tileSize: number = 256;

  lat: number = 49;
  lng: number = 32;
  zoom: number = 7;
  landcover: google.maps.ImageMapType;

  menuIsOpen: boolean;
  listItemIsOpen: number;

  constructor() { }

  ngOnInit() {
    var mapProp = {
      center: new google.maps.LatLng(this.lat, this.lng),
      zoom: this.zoom,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    this.map = new google.maps.Map(this.gmapElement.nativeElement, mapProp);

    let tileSize = new google.maps.Size(this.tileSize, this.tileSize);
    this.landcover = new google.maps.ImageMapType({
      getTileUrl: (coord, zoom) => this.getTileUrl(coord, zoom),
      name: "Kadastr",
      alt: "Ukraine kadastr",
      minZoom: 0,
      maxZoom: 19,
      opacity: 1.0,
      tileSize: tileSize
    });

  }

  ngAfterViewInit(): void {

  }

  toggle(checked: boolean) {
    this.isKadastrLayer = checked;
    if (this.isKadastrLayer) {
      this.map.overlayMapTypes.push(this.landcover);
    } else {
      this.map.overlayMapTypes.pop();
    }
  }

  toggleSidebar() {
    this.menuIsOpen = !this.menuIsOpen;
  }

  toggleListItem(number: number) {
    if(this.listItemIsOpen === number) {
      this.listItemIsOpen = null;
    } else {
      this.listItemIsOpen = number;
    }
  }

  xyzToBounds(x: number, y: number, z: number): number[] {
    console.log(x, y, z);
    debugger;
    var tileSize = (this.EXTENT[1] * 2) / Math.pow(2, z);
    var minx = this.EXTENT[0] + x * tileSize;
    var maxx = this.EXTENT[0] + (x + 1) * tileSize;
    // remember y origin starts at top
    var miny = this.EXTENT[1] - (y + 1) * tileSize;
    var maxy = this.EXTENT[1] - y * tileSize;
    console.log([minx, miny, maxx, maxy]);
    return [minx, miny, maxx, maxy];
  }

  getTileUrl(coordinates: google.maps.Point, zoom: number): string {
    return "https://map.land.gov.ua/geowebcache/service/wms?"
      + "REQUEST=GetMap&SERVICE=WMS"
      + "&VERSION=1.1.1&LAYERS=kadastr"
      + "&FORMAT=image%2Fpng&SRS=EPSG:3857"
      + "&WIDTH=" + this.tileSize
      + "&HEIGHT=" + this.tileSize
      + "&BBOX=" + this.xyzToBounds(coordinates.x, coordinates.y, zoom).join(",");
  };
}
