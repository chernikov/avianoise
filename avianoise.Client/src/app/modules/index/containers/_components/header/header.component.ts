import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @ViewChild('searchInput', { static: false }) searchInput: ElementRef;

  @Input() searchIsActive: boolean;
  @Input() setLocationActive: boolean;
  @Input() containerMode: number;
  @Input() menuIsOpen: boolean;
  @Output() openMenu = new EventEmitter();
  @Output() closeSidebar = new EventEmitter();
  @Output() openSearch = new EventEmitter();
  @Output() searchLocation = new EventEmitter();
  @Output() closeSetLocation = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  onOpenMenu() {
    this.openMenu.emit();
  }

  onCloseSidebar() {
    this.closeSidebar.emit();
  }

  onSearch() {
    this.openSearch.emit();
    setTimeout(() => {
      this.searchInput.nativeElement.focus();
    }, 0);
  }

  whenSearchLocation(value: string) {
    this.searchLocation.emit(value);
  }

  onCloseSearch() {
    this.closeSetLocation.emit();
  }
}
