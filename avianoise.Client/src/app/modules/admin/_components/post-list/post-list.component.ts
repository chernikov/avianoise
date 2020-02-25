import { Component, OnInit } from '@angular/core';
import { Post } from '@classes/post.class';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit {
  posts: Post[];
  constructor() {
    this.posts = [];
  }

  ngOnInit() {
    this.getPosts();
  }

  getPosts() {
    
  }
}
