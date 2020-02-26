import { Component, OnInit, OnDestroy } from '@angular/core';
import { FeedbackService } from '@services/feedback.service';
import { takeWhile } from 'rxjs/operators';
import { Feedback } from '@classes/feedback.class';

interface IPagination {
  perPage:number;
  current:number;
}

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.scss']
})
export class FeedbacksComponent implements OnInit, OnDestroy {
  alive: boolean = true;
  totalPages: number;
  feedbackList: Feedback[];
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
    this.getPageOfFeedbacks(1);
  }

  getPageOfFeedbacks(page: number) {
    this.feedBackService.get(page - 1).pipe(takeWhile(() => this.alive)).subscribe(res => {
      this.totalPages = res.totalPages;
      this.feedbackList = res.items;
      this.pagination.current = page;
    });
  }

  changePage(page: number) {
    if(this.pagination.current != page) {
      this.pagination.current = page;
      this.getPageOfFeedbacks(page);
    }
  }

  deleteFeedback(feedback: Feedback) {
    this.feedBackService.delete(feedback.id, false).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      this.feedbackList = this.feedbackList.filter(item => item != feedback);
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
