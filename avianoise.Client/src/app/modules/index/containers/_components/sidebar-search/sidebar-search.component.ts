import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Airport } from '@classes/airport.class';

@Component({
  selector: 'app-sidebar-search',
  templateUrl: './sidebar-search.component.html',
  styleUrls: ['./sidebar-search.component.scss']
})
export class SidebarSearchComponent implements OnInit {
  @Input() airports: Airport[];
  @Output() onSelectAirport = new EventEmitter();

  constructor() { }

  ngOnInit() {
    console.log(this.airports);
  }

  onAirport(airport: Airport) {
    this.onSelectAirport.emit(airport);
  }

}
