import { Component, OnInit, OnDestroy } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { FileUploader } from 'ng2-file-upload';

import * as fromRoot from '@state/app.state';
import * as fromAuthState from '@state/auth/auth.state';

import { Airport } from '@classes/airport.class';
import { ActivatedRoute } from '@angular/router';
import { AirportService } from '@services/airport.service';
import { ZipService } from '@services/zip.service';
import { FileService } from '@services/file.service';
import { takeWhile } from 'rxjs/operators';
import { File } from '@classes/file.class';
import { Zip } from '@classes/zip.class';
import { AirportFileService } from '@services/airport-file.service';
import { FileDecodeService } from '@services/file-decode.service';
import { AirportLineService } from '@services/airport-line.service';
import { AirportZipService } from '@services/airport-zip.service';
import { ZipUnpackService } from '@services/zip-unpack.service';
import { LineService } from '@services/line.service';
import { ProxyLine } from 'src/app/models/proxy-classes/proxy-line.class';
import { ProxyFile } from 'src/app/models/proxy-classes/proxy-file.class';

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
  decodedFiles: ProxyFile[];
  lines: ProxyLine[];
  filteredLines: ProxyLine[];

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
    private airportLineService: AirportLineService,
    private lineService: LineService
  ) {
    this.lines = [];
    this.filteredLines = [];
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
          this.getDecodedFiles();
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
    this.airportFileService.get(this.airport.id, false).pipe(takeWhile(() => this.alive)).subscribe(files => {
      this.files = files;
    });
  }

  getDecodedFiles() {
    this.airportFileService.get(this.airport.id, true).pipe(takeWhile(() => this.alive)).subscribe(files => {
      let arr: ProxyFile[] = [];
      files.forEach(file => {
        let newLinesArr: ProxyLine[] = [];

        file.lines.forEach(line => {
          if(file.lines && file.lines.length) {
            let newLine: ProxyLine = {
              ...line,
              isSelect: false
            };
            newLinesArr.push(newLine);
          }
        });
        let newFile: ProxyFile = {
          ...file,
          isSelect: false,
          lines: newLinesArr
        };
        arr.push(newFile);
      })
      this.decodedFiles = arr;
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

  onDecodeFile(file: File) {
    this.fileDecodeService.get(file.id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      this.getDecodedFiles();
      file.isDecoded = true;
    });
  }

  switchFile(decodedFile: ProxyFile) {
    decodedFile.lines.map(line => {
      if(decodedFile.isSelect) {
        line.isSelect = true;
        this.filteredLines.push(line);
      } else {
        line.isSelect = false;
      }
    });
    this.filterLines();
  }

  switchLine(line: ProxyLine) {
    if(line.isSelect) {
      this.filteredLines.push(line);
    } else {
      this.filteredLines = this.filteredLines.filter(item => item.id != line.id);
    }
    this.checkFileSelect();
  }

  filterLines() {
    this.filteredLines = this.filteredLines.filter(line => line.isSelect);
  }

  checkFileSelect() {
    this.decodedFiles.map(file => {
      if(file.lines.some(line => line.isSelect)) {
        file.isSelect = true;
      } else {
        file.isSelect = false;
      }
    })
  }

  clearMap() {
    this.filteredLines.map(line => line.isSelect = false);
    this.filterLines();
    this.checkFileSelect();
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

  onDeleteDecodedFile(id: number) {
    this.fileService.delete(id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      this.getFiles();
      this.getDecodedFiles();
    });
  }

  onDeleteLine(id: number) {
    this.lineService.delete(id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      this.getDecodedFiles();
      this.filteredLines = this.filteredLines.filter(line => line.id != id);
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
