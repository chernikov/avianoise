import { Component, OnInit, Output, EventEmitter, OnDestroy, Input } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { IfSlideAnimation } from '@animations';
import { takeWhile } from 'rxjs/operators';
import { PostService } from '@services/post.service';
import { Post } from '@classes/post.class';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  animations: [
    IfSlideAnimation
  ]
})
export class SidebarComponent implements OnInit, OnDestroy {
  @Output() toggleKadastr = new EventEmitter();
  @Output() changeMapLayer = new EventEmitter();
  @Output() openPost = new EventEmitter();
  @Input() listItemIsOpen: string;
  @Input() selectedLayer: number;

  alive: boolean = true;
  postMenu: Post[];
  menuIsOpen: boolean;
  isKadastrLayer: boolean;

  constructor(
    private postService: PostService,
    private modalService: NgxSmartModalService
  ) { }

  ngOnInit() {
    this.getPostMenu();
  }

  getPostMenu() {
    this.postService.getAll(true).pipe(takeWhile(() => this.alive)).subscribe(postMenu => {
      this.postMenu = postMenu;
    });
  }

  toggleListItem(item: string) {
    if(this.listItemIsOpen === item) {
      this.listItemIsOpen = null;
    } else {
      this.listItemIsOpen = item;
    }
    /* if (this.listItemIsOpen === number) {
      this.listItemIsOpen = null;
    } else {
      this.listItemIsOpen = number;
    } */
  }

  onToggleKadastr() {
    this.toggleKadastr.emit(this.isKadastrLayer);
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

  ngOnDestroy() {
    this.alive = false;
  }
}
