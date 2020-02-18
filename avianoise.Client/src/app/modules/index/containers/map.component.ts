/// <reference types="@types/googlemaps" />
/// <reference types="@types/node" />

import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';

import { IfSlideAnimation } from '@animations';
import { AirportPublishedService } from '@services/airport-published.service';
import { NoiseLevelService } from '@services/noise-level.service';

import mapStylesJson from '../../../../assets/map.json';
import { Airport } from '@classes/airport.class.js';

var MarkerWithLabel = require('markerwithlabel')(google.maps);

export interface IMarkerCoords {
  lat: string;
  lng: string;
}

export interface INoiseInfo {
  value: string;
  src: string;
  text: string;
  noData: boolean;
}

export interface ILayersInfo {
  id: number;
  src: string;
  text: string;
  textShort: string;
  dayNightType: number;
  noiseType: number;
}

var layersInfo: ILayersInfo[] = [
  {
    id: 1,
    src: 'assets/images/day-equivalent.svg',
    text: 'Денний еквівалентний',
    textShort: 'Денний екв.',
    dayNightType: 1,
    noiseType: 2
  },
  {
    id: 2,
    src: 'assets/images/day-max.svg',
    text: 'Денний максимальний',
    textShort: 'Денний макс.',
    dayNightType: 1,
    noiseType: 1
  },
  {
    id: 3,
    src: 'assets/images/night-equivalent.svg',
    text: 'Нічний еквівалентний',
    textShort: 'Нічний екв.',
    dayNightType: 2,
    noiseType: 2
  },
  {
    id: 4,
    src: 'assets/images/night-max.svg',
    text: 'Нічний максимальний',
    textShort: 'Нічний макс.',
    dayNightType: 2,
    noiseType: 1
  }
]

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
  airports: Airport[];
  filteredAirports: Airport[];
  polygons: google.maps.Polygon[];
  filteredPolygons: google.maps.Polygon[];
  noiseInfo: INoiseInfo[];
  markerCoords: IMarkerCoords;
  showLocationInfo: boolean;
  selectedLayerInfo: ILayersInfo;
  showPolygons: boolean = false;

  constructor(
    private airportPublishedService: AirportPublishedService,
    private noiseLevelService: NoiseLevelService
  ) {
    this.polygons = [];
    this.noiseInfo = [];
  }

  ngOnInit() {
    let _this = this;
    var mapProp = {
      center: new google.maps.LatLng(this.lat, this.lng),
      zoom: this.zoom,
      mapTypeId: google.maps.MapTypeId.ROADMAP,
      disableDefaultUI: true,
      styles: []
    };
    mapProp.styles = mapStylesJson;
    this.map = new google.maps.Map(this.gmapElement.nativeElement, mapProp);

    this.map.addListener('click', function (event) {
      if (_this.setLocationActive) {
        _this.placeMarker(event.latLng, _this.map);
        _this.map.setOptions({
          draggableCursor: 'pointer'
        });
      };
    });

    this.map.addListener('bounds_changed', function() {
      _this.map.addListener('zoom_changed', function() {
        let zoom =_this.map.getZoom();

        if(zoom > 10 && !_this.showPolygons) {
          _this.showPolygons = true;
          _this.filterPolygons();
        } else if(zoom <= 10 && _this.showPolygons) {
          _this.showPolygons = false;
          _this.filterPolygons();
        };
      });
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
    this.getAirports();
    this.setInfoLayer();
  }

  getAirports() {
    this.airportPublishedService.get().subscribe(airports => {
      this.airports = airports;
      this.filterAirports(1);
      this.showAirports();
    });
  }

  showAirports() {
    
    this.airports.map(airport => {
      let location = {
        lat: airport.lat,
        lng: airport.lng
      }

      new MarkerWithLabel({
        position: location,
        map: this.map,
        icon: 'assets/images/plane-icon.svg',
        labelContent: airport.name,
        labelAnchor: new google.maps.Point(-15, 30),
        labelClass: "airport-label white-shadow-text",
        labelInBackground: false
      });
    });
  }

  filterAirports(type: number) {
    this.filteredAirports = [];
    let config = layersInfo.find(item => item.id == type);
    this.airports.map(airport => {
      let newAirport = { ...airport };
      newAirport.files = newAirport.files.filter(file => file.dayNightType == config.dayNightType && file.noiseType == config.noiseType);
      if (airport.files.length) {
        this.filteredAirports.push(newAirport);
      };
    });
    this.renderPolygons();
  }

  filterPolygons() {
    if(!this.showPolygons) {
      this.polygons.map(item => item.setMap(null));
    } else {
      this.polygons.map(item => item.setMap(this.map));
    }
  }

  renderPolygons() {
    if (this.polygons && this.polygons.length) {
      this.polygons.map(polygon => {
        polygon.setMap(null);
      });
      this.polygons = [];
    };
    this.filteredAirports.forEach(airport => {
      airport.files.forEach(file => {
        file.lines.forEach(line => {
          let bgColor;
          let strokeColor;
          if(line.level >= 70 ) {
            bgColor = '#FF3564';
            strokeColor = '#EF364C';
          } else if(line.level <= 50) {
            bgColor = '#F7D897';
            strokeColor = '#EBBD87';
          } else {
            bgColor = '#FC8E75';
            strokeColor = '#EE897B';
          }
          let polygon = new google.maps.Polygon({
            paths: line.points,
            clickable: false,
            fillColor: bgColor,
            strokeColor: 'red',
            strokeOpacity: .5,
            strokeWeight: 1
          });
          this.polygons.push(polygon);
          this.filterPolygons();
        });
      });
    });
  }

  changeMapLayer() {
    this.layerIsChanged = true;
    this.setInfoLayer();
    this.filterAirports(this.selectedLayer);
  }

  placeMarker(location, map) {
    if (this.marker == null) {
      this.marker = new google.maps.Marker({
        position: location,
        map: map,
        icon: {
          url: 'assets/images/white-marker.svg',
          anchor: {
            x: 13,
            y: 29,
            equals() {return false}
          }
        }
      });
    } else {
      this.marker.setPosition(location);
      this.marker.setMap(this.map);
    }
    this.getLocationNoise();
  }

  getLocationNoise() {
    let lat = this.marker.getPosition().lat();
    let lng = this.marker.getPosition().lng();

    this.markerCoords = {
      lat: lat.toString().slice(0, 10),
      lng: lng.toString().slice(0, 10)
    };
    this.noiseLevelService.get(lat, lng).subscribe(noiseInfoArray => {
      this.setNoiseLevelInfo(noiseInfoArray);
    });
  }

  setNoiseLevelInfo(noiseInfoArray) {
    this.noiseInfo = [];
    layersInfo.map(item => {
      let noiseLevelItem: INoiseInfo;
      let layerInfo = noiseInfoArray.find(noiseInfoItem => noiseInfoItem.dayNightType == item.dayNightType && noiseInfoItem.noiseType == item.noiseType);
      if(layerInfo) {
        let level: string;
        if(layerInfo.level >= 85) {
          level = '>' + layerInfo.level;
        } else level = layerInfo.level + '-' + (layerInfo.level + 5);
        noiseLevelItem = {
          value: level,
          text: item.textShort,
          src: item.src,
          noData: false
        };
      } else {
        noiseLevelItem = {
          value: 'Немає даних',
          text: item.textShort,
          src: item.src,
          noData: true
        }
      }
      this.noiseInfo.push(noiseLevelItem);
    });
    this.showLocationInfo = true;
  }

  ngAfterViewInit(): void { }

  onSetLocationBtn() {
    this.setLocationActive = !this.setLocationActive;
    if (!this.setLocationActive) {
      this.showLocationInfo = false;
      this.marker.setMap(null);
      this.map.setOptions({
        draggableCursor: 'grab'
      });
    }
  }

  setInfoLayer() {
    this.selectedLayerInfo = layersInfo.find(layer => layer.id === this.selectedLayer);
  }

  onNoiseInfo() {
    this.menuIsOpen = true;
    this.listItemIsOpen = 3;
  }

  zoomIn() {
    let zoom = this.map.getZoom();
    this.map.setZoom(zoom + 2);
  }

  zoomOut() {
    let zoom = this.map.getZoom();
    this.map.setZoom(zoom - 2);
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
