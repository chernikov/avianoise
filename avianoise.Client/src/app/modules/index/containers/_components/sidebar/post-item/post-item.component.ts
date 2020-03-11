import { Component, Input, Output, EventEmitter } from '@angular/core';


@Component({
    selector: 'app-post-item',
    template: `  
            <div class="post-title" (click)="openItem()">
                <span>{{ item.title }}</span>
            </div>
            <div *ngIf="item && item.posts && item.posts.length" class="sub-items">
                <app-post-item *ngFor="let post of item.posts" [item]="post" (open)="open.emit($event)"></app-post-item>
            </div>`,
    styleUrls: ['post-item.component.scss']
  })
  export class PostItemComponent  {
  
    @Input('item') item;

    @Output('open') open : EventEmitter<number> = new EventEmitter<number>();

    openItem() {
      debugger;
      if (!this.item.posts || !this.item.posts.length) {
        this.open.emit(this.item.id);
      }
    }
  }
  