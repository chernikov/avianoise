import { Component, OnInit, OnDestroy } from '@angular/core';
import { Post } from '@classes/post.class';
import { takeWhile } from 'rxjs/operators';
import { PostService } from '@services/post.service';
import { PostOrderService } from '@services/post-order.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit, OnDestroy {
  alive: boolean = true;

  posts: Post[];

  constructor(
    private postService: PostService,
    private postOrderService : PostOrderService
  ) {
    this.posts = [];
  }

  ngOnInit() {
    this.getPosts();
  }

  getPosts() {
    this.postService.getAll(false).pipe(takeWhile(() => this.alive)).subscribe(posts => {
      this.posts = posts;
    });
  }

  updateAllOrder(list : Post[]) {
    this.updateOrder(list);
    list.forEach(p => {
      if (p.posts && p.posts.length)
      {
        this.updateAllOrder(p.posts);
      }
    })
  }

 
  updateAll() {
    this.getPosts();
  }

  downItem(event : Post) {
    var sublings = this.findSublings(this.posts, event.id);
    sublings.sort((a, b) =>  a.order - b.order);
    var next = sublings.find(p => p.order > event.order);
    var order = next.order;
    next.order = event.order;
    event.order = order;
    this.updateOrder(sublings);
  }

  upItem(event : Post) {
    var sublings = this.findSublings(this.posts, event.id);
    sublings.sort((a, b) =>  a.order - b.order);
    var prev = sublings.find(p => p.order < event.order);
    var order = prev.order;
    prev.order = event.order;
    event.order = order;
    this.updateOrder(sublings);
  }
  

  leftItem(event : Post) {
    var sublings = this.findSublings(this.posts, event.postId);
    if (sublings && sublings.length) {
      event.postId = sublings[0].postId;
    } else {
      event.postId = null;
    }
    this.postService.put(event).pipe(takeWhile(() => this.alive)).subscribe(p =>  {
      this.updateAll();
    });
  }

  rightItem(event : Post) {
    var sublings = this.findSublings(this.posts, event.id);
    sublings.sort((a, b) =>  b.order - a.order);
    var prev = sublings.find(p => p.order < event.order);
    event.postId = prev.id;
    this.postService.put(event).pipe(takeWhile(() => this.alive)).subscribe(p =>  this.updateAll());
  }

  
  findSublings(list : Post[], id: number) : Post[] 
  {
    var item = list.find(p => p.id == id);
    if (item) {
      return list;
    }
    let sublings = null;
    list.forEach(element => {
      if (element.posts && element.posts.length && this.findSublings(element.posts, id)) {
        sublings =  this.findSublings(element.posts, id);
      }
    });
    return sublings;
  }

  updateOrder(sublings : Post[]) {
    sublings.sort((a, b) =>  a.order - b.order);
    let i = 1;
    sublings.forEach(element => {
      element.order = i;
      i++; 
    });
    this.postOrderService.post(this.posts).pipe(takeWhile(() => this.alive)).subscribe(p =>  this.updateAll());
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
