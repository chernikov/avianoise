import { Component, Input, Output, EventEmitter } from '@angular/core';


@Component({
    selector: 'app-practice-item',
    template: `  
            <div class="practice-title" (click)="openItem()">
                <span>{{ item.title }}</span>
            </div>
            <div *ngIf="item && item.practices && item.practices.length" class="sub-items">
                <app-practice-item *ngFor="let practice of item.practices" [item]="practice" (open)="open.emit($event)"></app-practice-item>
            </div>`,
    styleUrls: ['practice-item.component.scss']
  })
  export class PracticeItemComponent  {
  
    @Input('item') item;

    @Output('open') open : EventEmitter<number> = new EventEmitter<number>();

    openItem() {
      if (!this.item.practices || !this.item.practices.length) {
        this.open.emit(this.item.id);
      }
    }
  }
  