import { Component, OnInit, OnDestroy } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { FileUploader } from 'ng2-file-upload';

import * as fromRoot from '@state/app.state';
import * as fromAuthState from '@state/auth/auth.state';
import * as fromAirportsActions from '@state/airports/airports.actions';
import * as fromAirportsState from '@state/airports/airports.state';

import { Airport } from '@classes/airport.class';
import { ActivatedRoute } from '@angular/router';
import { AirportService } from '@services/airport.service';
import { ZipService } from '@services/zip.service';
import { FileService } from '@services/file.service';
import { takeWhile, take } from 'rxjs/operators';
import { AirportZip } from '@classes/airport-zip.class';
import { File } from '@classes/file.class';
import { Line } from '@classes/line.class';
import { LineService } from '@services/lines.service';

@Component({
  selector: 'app-airport',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.scss']
})
export class AirportComponent implements OnInit, OnDestroy {
  alive: boolean = true;
  airport: Airport;
  airportIsLoad: boolean;
  url: string;
  token: string;
  zipList: AirportZip[];
  files: File[];
  lines: Line[];
  public uploader: FileUploader

  constructor(
    private store: Store<fromRoot.State>,
    private route: ActivatedRoute,
    private airportService: AirportService,
    private zipService: ZipService,
    private fileService: FileService,
    private lineService: LineService
  ) {
    this.lines = [];
    this.airportIsLoad = false;
  }

  ngOnInit() {
    this.getToken();
    this.getAirport();
  }

  getToken() {
    this.store.pipe(select(fromAuthState.getToken), takeWhile((() => this.alive))).subscribe(token => {
      this.token = 'Bearer ' + token;
      this.createUploader();
    });
  }

  getAirport() {
    this.route.params.subscribe(param => {
      this.airportService.getAirport(param.id).pipe(takeWhile(() => this.alive)).subscribe(airport => {
        if(airport) {
          this.airport = airport;
          this.airportIsLoad = true;
          this.url = 'api/airport/zip/' + airport.id;
          this.getZips();
          this.getFiles();
          this.getLines();
          this.createUploader();
        }
      });
    });
  }

  getZips() {
    this.zipService.get(this.airport.id).pipe(takeWhile(() => this.alive)).subscribe(zips => {
      this.zipList = zips;
    });
  }

  getFiles() {
    this.fileService.get(this.airport.id).pipe(takeWhile(() => this.alive)).subscribe(files => {
      this.files = files;
    });
  }

  getLines() {
    this.lineService.getAll(this.airport.id).pipe(takeWhile(() => this.alive)).subscribe(lines => {
      this.lines = lines;
    });
  }

  createUploader() {
    this.uploader = new FileUploader({
      url: this.url,
      authToken: this.token
    });
    this.uploader.onCompleteAll = () => {
      this.getZips();
    }
  }

  onUnpack(id: number) {
    this.zipService.unpack(id).pipe(takeWhile(() => this.alive)).subscribe(files => {
      this.files = this.files.concat(files);
    });
  }

  onDecodeFile(id: number) {
    this.fileService.decode(id).pipe(takeWhile(() => this.alive)).subscribe(lines => {
      this.lines = this.lines.concat(lines);
      console.log(this.lines);
    });
  }

  onDeleteZip(id: number) {
    this.zipService.delete(id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      this.getZips();
    });
  }

  onDeleteFile(id: number) {
    this.fileService.delete(id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      this.getFiles();
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
