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
import { takeWhile } from 'rxjs/operators';
import { File } from '@classes/file.class';
import { Line } from '@classes/line.class';
import { Zip } from '@classes/zip.class';
import { AirportFileService } from '@services/airport-file.service';
import { FileDecodeService } from '@services/file-decode.service';
import { AirportLineService } from '@services/airport-line.service';
import { AirportZipService } from '@services/airport-zip.service';
import { ZipUnpackService } from '@services/zip-unpack.service';

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
  zipList: Zip[];
  files: File[];
  lines: Line[];
  public uploader: FileUploader

  constructor(
    private store: Store<fromRoot.State>,
    private route: ActivatedRoute,
    private airportService: AirportService,
    private airportZipService: AirportZipService,
    private fileService: FileService,
    private zipService: ZipService,
    private zipUnpackService: ZipUnpackService,
    private airportFileService: AirportFileService,
    private fileDecodeService: FileDecodeService,
    private airportLineService: AirportLineService
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
      this.airportService.get(param.id).pipe(takeWhile(() => this.alive)).subscribe(airport => {
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
    this.airportZipService.get(this.airport.id).pipe(takeWhile(() => this.alive)).subscribe(zips => {
      this.zipList = zips;
    });
  }

  getFiles() {
    this.airportFileService.get(this.airport.id).pipe(takeWhile(() => this.alive)).subscribe(files => {
      this.files = files;
    });
  }

  getLines() {
    this.airportLineService.get(this.airport.id).pipe(takeWhile(() => this.alive)).subscribe(lines => {
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
    this.zipUnpackService.get(id).pipe(takeWhile(() => this.alive)).subscribe(files => {
      this.files = this.files.concat(files);
    });
  }

  onDecodeFile(id: number) {
    this.fileDecodeService.get(id).pipe(takeWhile(() => this.alive)).subscribe(lines => {
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
