import { Component, OnInit, OnDestroy } from '@angular/core';
import { Post } from '@classes/post.class';
import { takeWhile } from 'rxjs/operators';
import { PostService } from '@services/post.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit, OnDestroy {
  alive: boolean = true;
  posts: Post[];

  constructor(
    private postService: PostService
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

  deletePost(post: Post) {
    this.postService.delete(post.id).pipe(takeWhile(() => this.alive)).subscribe(_ => {
      this.posts = this.posts.filter(item => item != post);
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
