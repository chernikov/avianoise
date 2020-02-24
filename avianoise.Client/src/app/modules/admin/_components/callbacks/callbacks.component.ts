import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '@services/feedback.service';
import { takeWhile } from 'rxjs/operators';
import { Feedback } from '@classes/feedback.class';

interface IPagination {
  perPage:number;
  current:number;
}

@Component({
  selector: 'app-callbacks',
  templateUrl: './callbacks.component.html',
  styleUrls: ['./callbacks.component.scss']
})
export class CallbacksComponent implements OnInit {
  alive: boolean = true;
  totalPages: number;
  callbackList: Feedback[];
  pagination: IPagination;
  constructor(
    private feedBackService: FeedbackService
  ) {
    this.pagination = {
      perPage: 20,
      current: 1
    };
  }

  ngOnInit() {
    this.getPageOfCallbacks(1);
  }

  getPageOfCallbacks(page: number) {
    this.feedBackService.get(page - 1).pipe(takeWhile(() => this.alive)).subscribe(res => {
      this.totalPages = res.totalPages;
      this.callbackList = res.items;
      this.pagination.current = page;
    });
  }

  downloadFile(fullPath: string) {
    console.log(fullPath);
  }

  changePage(page: number) {
    if(this.pagination.current != page) {
      this.pagination.current = page;
      this.getPageOfCallbacks(page);
    }
  }
}
