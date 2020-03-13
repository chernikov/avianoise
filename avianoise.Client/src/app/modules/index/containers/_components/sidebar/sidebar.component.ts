import { Component, OnInit, Output, EventEmitter, OnDestroy, Input } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { IfSlideAnimation } from '@animations';
import { takeWhile } from 'rxjs/operators';
import { PostService } from '@services/post.service';
import { Post } from '@classes/post.class';
import { Practice } from '@classes/practice.class';
import { PracticeService } from '@services/practice.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  animations: [
    IfSlideAnimation
  ]
})
export class SidebarComponent implements OnInit, OnDestroy {
  @Output() changeMapLayer = new EventEmitter();
  @Output() openPost = new EventEmitter();
  @Output() openPractice = new EventEmitter();
  @Input() listItemIsOpen: string;
  @Input() selectedLayer: number;

  alive: boolean = true;
  postMenu: Post[];
  practiceMenu: Practice[];

  menuIsOpen: boolean;

  constructor(
    private postService: PostService,
    private practiceService : PracticeService,
    private modalService: NgxSmartModalService
  ) { }

  ngOnInit() {
    this.getPostMenu();
    this.getPracticeMenu();
  }

  getPostMenu() {
    this.postService.getAll(true).pipe(takeWhile(() => this.alive)).subscribe(postMenu => {
      this.postMenu = postMenu;
    });
  }

  getPracticeMenu() {
    this.practiceService.getAll(true).pipe(takeWhile(() => this.alive)).subscribe(practiceMenu => {
      this.practiceMenu = practiceMenu;
    });
  }

  toggleListItem(item: string) {
    if(this.listItemIsOpen === item) {
      this.listItemIsOpen = null;
    } else {
      this.listItemIsOpen = item;
    }
  }

  onChangeMapLayer() {
    this.changeMapLayer.emit(this.selectedLayer);
  }

  openFeedbackModal() {
    this.modalService.getModal('feedbackModal').open();
  }

  onOpenPost(id: number) {
    this.openPost.emit(id);
  }

  onOpenPractice(id: number) {
    this.openPractice.emit(id);
  }


  ngOnDestroy() {
    this.alive = false;
  }
}
