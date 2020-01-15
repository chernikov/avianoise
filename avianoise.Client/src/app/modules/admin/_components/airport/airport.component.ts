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
import { AirportZipService } from '@services/airport-zip.service';
import { ZipUnpackService } from '@services/zip-unpack.service';
import { LineService } from '@services/line.service';
import { FileClearService } from '@services/file-clear.service';
import { ProxyExtendedFile } from '@proxy-classes/proxy-extended-file';
import { ProxyLine } from '@proxy-classes/proxy-line.class';
import { ProxyZip } from '@proxy-classes/proxy-zip.class';
import { ProxyFile } from '@proxy-classes/proxy-file.class';

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
  decodedFiles: ProxyExtendedFile[];
  lines: ProxyLine[];

  uploader: FileUploader;

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
    private lineService: LineService,
    private fileClearService: FileClearService
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
      this.token =  token;
      this.createUploader();
    });
  }

  getAirport() {
    this.route.params.subscribe(param => {
      this.airportService.get(param.id).pipe(takeWhile(() => this.alive)).subscribe(airport => {
        if (airport) {
          this.airport = airport;
          this.airportIsLoad = true;
          this.url = 'api/airport/zip/' + airport.id;
          this.getZips();
          this.getFiles();
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
      this.getDecodedFiles();
    });
  }

  getDecodedFiles() {
    let decodedFilesArr: ProxyExtendedFile[] = [];
    this.files.filter(file => file.isDecoded).forEach((file: ProxyExtendedFile) => {
      let newLinesArr: ProxyLine[] = [];
      if (file.lines && file.lines.length) {
        file.lines.forEach((line: ProxyLine) => newLinesArr.push(line));
      };
      decodedFilesArr.push(file);
    })
    this.decodedFiles = decodedFilesArr;
  }

  createUploader() {
    this.uploader = new FileUploader({
      url: this.url,
      authToken: 'Bearer ' + this.token
    });
    this.uploader.onCompleteAll = () => {
      this.getZips();
    }
  }

  onUnpack(zip: ProxyZip) {
    zip.isUnpacking = true;
    this.zipUnpackService.get(zip.id).pipe(takeWhile(() => this.alive)).subscribe(files => {
      zip.isUnpacking = false;
      this.files = this.files.concat(files);
    });
  }

  onDecodeFile(file: ProxyFile) {
    file.isDecoding = true;
    this.fileDecodeService.get(file.id, false).pipe(takeWhile(() => this.alive)).subscribe((res: ProxyExtendedFile) => {
      file.isDecoding = false;
      file.isDecoded = true;
      this.decodedFiles.push(res);
    });
  }

  toggleFile(decodedFile: ProxyExtendedFile) {
    decodedFile.lines.forEach(line => 
    {
      var proxyLine = line as ProxyLine;
      proxyLine.isSelect = decodedFile.isSelect;
      if (decodedFile.isSelect) {
        this.lines.push(proxyLine);
      } 
    });
    this.lines = this.lines.filter(line => line.isSelect);
  }

  toggleLine(line: ProxyLine) {
    if (line.isSelect) {
      this.lines.push(line);
    } else {
      this.lines = this.lines.filter(item => item.id != line.id);
    }
    this.checkFileSelected();
  }

  checkFileSelected() {
    this.decodedFiles.forEach(file => {
      file.isSelect = file.lines.some((line : ProxyLine) => line.isSelect);
    });
  }

  clearMap() 
  {
    this.lines = [];
    this.decodedFiles.forEach(file => { file.isSelect = false; });
  }

  onDeleteZip(zip: ProxyZip) {
    zip.isDeleting = true;
    this.zipService.delete(zip.id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      zip.isDeleting = false;
      this.getZips();
    });
  }

  onDeleteFile(file: ProxyFile) {
    file.isDeleting = true;
    this.fileService.delete(file.id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      file.isDeleting = false;
      this.files = this.files.filter(item => item.id != file.id);
      this.decodedFiles = this.decodedFiles.filter(item => item.id != file.id);
    });
  }

  onDeleteDecodedFile(file: ProxyFile) {
    file.isDeleting = true;
    this.fileClearService.get(file.id).pipe(takeWhile(() => this.alive)).subscribe(res => {
      file.isDeleting = false;
      this.files.forEach(file => file.id === res.id ? file.isDecoded = false : null);
      this.decodedFiles = this.decodedFiles.filter(file => file.id != res.id);
      this.lines = this.lines.filter(line => line.fileId != file.id);
    });
  }

  onDeleteLine(line: ProxyLine) {
    line.isDeleting = true;
    this.lineService.delete(line.id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      line.isDeleting = false;
      this.lines = this.lines.filter(item => item.id != line.id);
      this.decodedFiles.map(file => {
        if(file.id === line.fileId) {
          file.lines = file.lines.filter(item => item.id != line.id);
          this.checkFileSelected();
          if(!file.lines.length) {
            this.decodedFiles = this.decodedFiles.filter(item => item.id != line.fileId);
            this.files.forEach(item => item.id === file.id ? item.isDecoded = false : null);
          }
        }
      });
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
