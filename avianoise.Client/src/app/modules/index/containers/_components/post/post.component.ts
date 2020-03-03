import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '@services/post.service';
import { takeWhile } from 'rxjs/operators';
import { Post } from '@classes/post.class';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit, OnDestroy {

  alive: boolean = true;
  post: Post

  constructor(
    private route: ActivatedRoute,
    private postService: PostService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      console.log(params.id);
      this.getPost(params.id);
    });
  }

  getPost(id: number) {
    this.postService.get(id).pipe(takeWhile(() => this.alive)).subscribe(post => {
      this.post = post;
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }

}
