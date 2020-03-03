import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-noise-info',
  templateUrl: './noise-info.component.html',
  styleUrls: ['./noise-info.component.scss']
})
export class NoiseInfoComponent implements OnInit {
  @Input() markerCoords;
  @Input() noiseInfo;
  @Output() changeMapLayer = new EventEmitter<number>()
  constructor() { }

  ngOnInit() {
  }

  onChangeMapLayer(layer: number) {
    this.changeMapLayer.emit(layer);
  }
}
