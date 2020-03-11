import { Component, OnInit, OnDestroy } from '@angular/core';
import { Practice } from '@classes/practice.class';
import { takeWhile } from 'rxjs/operators';
import { PracticeService } from '@services/practice.service';
import { PracticeOrderService } from '@services/practice-order.service';

@Component({
  selector: 'app-practice-list',
  templateUrl: './practice-list.component.html',
  styleUrls: ['./practice-list.component.scss']
})
export class PracticeListComponent implements OnInit, OnDestroy {
  alive: boolean = true;

  practices: Practice[];

  constructor(
    private practiceService: PracticeService,
    private practiceOrderService : PracticeOrderService
  ) {
    this.practices = [];
  }

  ngOnInit() {
    this.getPractices();
  }

  getPractices() {
    this.practiceService.getAll(false).pipe(takeWhile(() => this.alive)).subscribe(practices => {
      this.practices = practices;
    });
  }

  updateAllOrder(list : Practice[]) {
    this.updateOrder(list);
    list.forEach(p => {
      if (p.practices && p.practices.length)
      {
        this.updateAllOrder(p.practices);
      }
    })
  }

 
  updateAll() {
    this.getPractices();
  }

  downItem(event : Practice) {
    var sublings = this.findSublings(this.practices, event.id);
    sublings.sort((a, b) =>  a.order - b.order);
    var next = sublings.find(p => p.order > event.order);
    var order = next.order;
    next.order = event.order;
    event.order = order;
    this.updateOrder(sublings);
  }

  upItem(event : Practice) {
    var sublings = this.findSublings(this.practices, event.id);
    sublings.sort((a, b) =>  a.order - b.order);
    var prev = sublings.find(p => p.order < event.order);
    var order = prev.order;
    prev.order = event.order;
    event.order = order;
    this.updateOrder(sublings);
  }
  

  leftItem(event : Practice) {
    var sublings = this.findSublings(this.practices, event.practiceId);
    if (sublings && sublings.length) {
      event.practiceId = sublings[0].practiceId;
    } else {
      event.practiceId = null;
    }
    this.practiceService.put(event).pipe(takeWhile(() => this.alive)).subscribe(p =>  {
      this.updateAll();
    });
  }

  rightItem(event : Practice) {
    var sublings = this.findSublings(this.practices, event.id);
    sublings.sort((a, b) =>  b.order - a.order);
    var prev = sublings.find(p => p.order < event.order);
    event.practiceId = prev.id;
    this.practiceService.put(event).pipe(takeWhile(() => this.alive)).subscribe(p =>  this.updateAll());
  }

  
  findSublings(list : Practice[], id: number) : Practice[] 
  {
    var item = list.find(p => p.id == id);
    if (item) {
      return list;
    }
    let sublings = null;
    list.forEach(element => {
      if (element.practices && element.practices.length && this.findSublings(element.practices, id)) {
        sublings =  this.findSublings(element.practices, id);
      }
    });
    return sublings;
  }

  updateOrder(sublings : Practice[]) {
    sublings.sort((a, b) =>  a.order - b.order);
    let i = 1;
    sublings.forEach(element => {
      element.order = i;
      i++; 
    });
    this.practiceOrderService.post(this.practices).pipe(takeWhile(() => this.alive)).subscribe(p =>  this.updateAll());
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
