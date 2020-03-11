import { Component, OnInit, Input, OnDestroy, Output, EventEmitter } from '@angular/core';
import { Practice } from '@classes/practice.class';
import { NbIconLibraries } from '@nebular/theme';
import { PracticeService } from '@services/practice.service';
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'app-practice-item',
  templateUrl: './practice-item.component.html',
  styleUrls: ['./practice-item.component.scss']
})
export class PracticeItemComponent implements OnInit, OnDestroy {
  
  alive: boolean = true;

  @Input('item') item : Practice;

  @Input('isFirst') isFirst : boolean;
  @Input('isLast') isLast : boolean;
  @Output('update') update : EventEmitter<null> = new EventEmitter();
  
  @Output('up') up : EventEmitter<Practice> = new EventEmitter();
  @Output('down') down : EventEmitter<Practice> = new EventEmitter<Practice>();
 
  @Output('left') left : EventEmitter<Practice> = new EventEmitter<Practice>();
  @Output('right') right : EventEmitter<Practice> = new EventEmitter<Practice>();


  constructor(private iconsLibrary: NbIconLibraries, 
    private  practiceService : PracticeService) { 
    iconsLibrary.registerFontPack('fa', { packClass: 'fa', iconClassPrefix: 'fa' });
    iconsLibrary.registerFontPack('far', { packClass: 'far', iconClassPrefix: 'fa' });
  }

 

  deletePractice(practice: Practice) {
     this.practiceService.delete(practice.id).pipe(takeWhile(() => this.alive)).subscribe(_ =>  this.update.emit(null) );
  }

  downPractice() 
  {
    this.down.emit(this.item);
  }

  upPractice() 
  {
    this.up.emit(this.item);
  }

  leftPractice() 
  {
    this.left.emit(this.item);
  }

  rightPractice() 
  {
    this.right.emit(this.item);
  }

  ngOnInit() {
  }

  ngOnDestroy(): void {
    this.alive = false;
  }
}
