import { Component, OnInit } from '@angular/core';
import { PostService } from '@services/post.service';
import { takeWhile } from 'rxjs/operators';
import { Post } from '@classes/post.class';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  alive: boolean = true;
  post: Post;

  constructor(
    private postService: PostService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getPost();
  }

  getPostId(): number {
    let id: number;
    this.route.params.subscribe(param => {
      id = param.id;
    });
    return id;
  }

  getPost() {
    this.postService.get(this.getPostId()).pipe(takeWhile(() => this.alive)).subscribe(post => {
      this.post = post;
      console.log(post);
    });
  }
}
