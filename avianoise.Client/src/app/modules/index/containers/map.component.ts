/// <reference types="@types/googlemaps" />
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';

import { IfSlideAnimation } from '@animations';
import { AirportPublishedService } from '@services/airport-published.service';
import { NoiseLevelService } from '@services/noise-level.service';

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
  marker: google.maps.Marker;

  EXTENT = [-Math.PI * 6378137, Math.PI * 6378137];

  tileSize: number = 256;

  lat: number = 49;
  lng: number = 32;
  zoom: number = 7;
  landcover: google.maps.ImageMapType;

  menuIsOpen: boolean;
  listItemIsOpen: number;
  setLocationActive: boolean;
  selectedLayer: number = 1;
  layerIsChanged: boolean;

  constructor(
    private airportPublishedService: AirportPublishedService,
    private noiseLevelService: NoiseLevelService
  ) { }

  ngOnInit() {
    let _this = this;
    var mapProp = {
      center: new google.maps.LatLng(this.lat, this.lng),
      zoom: this.zoom,
      mapTypeId: google.maps.MapTypeId.ROADMAP,
      disableDefaultUI: true
    };
    this.map = new google.maps.Map(this.gmapElement.nativeElement, mapProp);
    this.map.addListener('click', function (event) {
      if (_this.setLocationActive) {
        _this.placeMarker(event.latLng, _this.map);
        _this.map.setOptions({
          draggableCursor: 'pointer'
        });
      }
    });

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
    this.addControlesForMap();
    this.getAirports();
  }

  getAirports() {
    this.airportPublishedService.get().subscribe(res => {
      let test = res;
      test.forEach(file => {
        file.lines.forEach(line => {
          let polygon = new google.maps.Polygon({
            paths: line.points,
            clickable: false
          });
          polygon.setMap(this.map);
        })
      })
    });
  }

  changeMapLayer() {
    this.layerIsChanged = true;
    this.createInfoLayer();
  }

  placeMarker(location, map) {
    if (this.marker == null) {
      this.marker = new google.maps.Marker({
        position: location,
        map: map,
        icon: 'assets/images/white-marker.svg'
      });
    } else { this.marker.setPosition(location); }
    this.getLocationNoise();
  }

  getLocationNoise() {
    let lat = this.marker.getPosition().lat();
    let lng = this.marker.getPosition().lng();
    console.log('lat', lat, 'lng', lng);
    this.noiseLevelService.get(lat, lng).subscribe(res => {
      console.log(res);
    });
  }

  addControlesForMap() {
    this.createNoiseLevelInfoButton();
    this.createBottomRightButtons();
    this.createSetLocationButton();
    this.createInfoLayer();
  }

  ngAfterViewInit(): void {

  }

  createSetLocationButton() {
    let _this = this;

    let setLocationControlDiv = document.createElement('div');
    setLocationControlDiv.className = 'set-location-wrap';

    let icon = document.createElement('img');
    icon.setAttribute('src', 'assets/images/blue-marker.svg');

    let span = document.createElement('span');
    span.innerHTML = 'Вибрати локацію';

    setLocationControlDiv.appendChild(icon);
    setLocationControlDiv.appendChild(span);

    setLocationControlDiv.addEventListener('click', function () {
      _this.setLocationActive = !_this.setLocationActive;
      if (_this.setLocationActive) {
        icon.setAttribute('src', 'assets/images/left-arrow.svg');
        span.innerHTML = 'Вийти з вибору локації';
      } else {
        icon.setAttribute('src', 'assets/images/blue-marker.svg');
        span.innerHTML = 'Вибрати локацію';
        _this.map.setOptions({
          draggableCursor: 'grab'
        });
      }
    });

    this.map.controls[google.maps.ControlPosition.LEFT_BOTTOM].push(setLocationControlDiv);
  }

  createInfoLayer() {
    let layersInfo = [
      {
        id: 1,
        src: 'assets/images/day-equivalent.svg',
        text: 'Денний еквівалентний'
      },
      {
        id: 2,
        src: 'assets/images/day-max.svg',
        text: 'Денний максимальний'
      },
      {
        id: 3,
        src: 'assets/images/night-equivalent.svg',
        text: 'Нічний еквівалентний'
      },
      {
        id: 4,
        src: 'assets/images/night-max.svg',
        text: 'Нічний максимальний'
      }
    ]

    let selectedLayerInfo = layersInfo.find(layer => layer.id === this.selectedLayer);

    if(!this.layerIsChanged) {
  
      let img = document.createElement('img');
      img.setAttribute('src', selectedLayerInfo.src);
  
      let span = document.createElement('span');
      span.innerHTML = selectedLayerInfo.text;
  
      let wrapDiv = document.createElement('div');
      wrapDiv.className = 'layer-info-wrap';
  
      wrapDiv.appendChild(img);
      wrapDiv.appendChild(span);
  
      this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(wrapDiv);
    } else {
      let img = document.querySelector('.layer-info-wrap img');
      img.setAttribute('src', selectedLayerInfo.src);
      let span = document.querySelector('.layer-info-wrap span');
      span.innerHTML = selectedLayerInfo.text;
    }
  }

  createNoiseLevelInfoButton() {
    let _this = this;

    let noiseLevelControlDiv = document.createElement('div');
    noiseLevelControlDiv.className = 'noise-control-wrap';

    let createChildDiv = function (html: string, className: string) {
      let div = document.createElement('div');
      div.innerHTML = html;
      div.className = className;
      return div;
    }

    noiseLevelControlDiv.appendChild(createChildDiv('75-85', 'hight'));
    noiseLevelControlDiv.appendChild(createChildDiv('65-75', 'medium'));
    noiseLevelControlDiv.appendChild(createChildDiv('50-65', 'low'));
    noiseLevelControlDiv.appendChild(createChildDiv('info', 'info'));

    noiseLevelControlDiv.addEventListener('click', function () {
      _this.menuIsOpen = true;
      _this.listItemIsOpen = 3;
    });

    this.map.controls[google.maps.ControlPosition.TOP_RIGHT].push(noiseLevelControlDiv);
  }

  createMyLocationButton() {
    var _this = this;

    let locationButton = document.createElement('div');
    locationButton.className = 'my-location-button'
    let locationButtonIcon = document.createElement('img');
    locationButtonIcon.setAttribute('src', 'assets/images/location.svg');

    locationButton.appendChild(locationButtonIcon);
    locationButton.addEventListener('click', function () {
      if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
          var pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
          };
          _this.map.setCenter(pos);
          _this.map.setZoom(12);
        });
      }
    });

    return locationButton;
  }

  createScaleButton() {
    let _this = this;

    let scaleButton = document.createElement('div');
    scaleButton.className = 'scale-button';
    let top = document.createElement('div');
    top.className = 'scale-button-top';
    let bottom = document.createElement('div');
    bottom.className = 'scale-button-bottom';

    top.addEventListener('click', function() {
      let zoom = _this.map.getZoom();
      _this.map.setZoom(zoom + 2);
    });

    bottom.addEventListener('click', function() {
      let zoom = _this.map.getZoom();
      _this.map.setZoom(zoom - 2);
    });

    scaleButton.appendChild(top);
    scaleButton.appendChild(bottom);

    return scaleButton;
  }

  createBottomRightButtons() {
    let rightBottomButtons = document.createElement('div');
    rightBottomButtons.className = 'right-bottom-buttons-wrap';
    let scaleButton = this.createScaleButton();
    let locationButton = this.createMyLocationButton();

    rightBottomButtons.appendChild(scaleButton);
    rightBottomButtons.appendChild(locationButton);

    this.map.controls[google.maps.ControlPosition.RIGHT_BOTTOM].push(rightBottomButtons);
  }

  toggleKadastr(checked: boolean) {
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
    if (this.listItemIsOpen === number) {
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
