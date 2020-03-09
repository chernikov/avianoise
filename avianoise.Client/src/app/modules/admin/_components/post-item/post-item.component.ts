import { Component, OnInit, Input, OnDestroy, Output, EventEmitter } from '@angular/core';
import { Post } from '@classes/post.class';
import { NbIconLibraries } from '@nebular/theme';
import { PostService } from '@services/post.service';
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'app-post-item',
  templateUrl: './post-item.component.html',
  styleUrls: ['./post-item.component.scss']
})
export class PostItemComponent implements OnInit, OnDestroy {
  
  alive: boolean = true;

  @Input('item') item : Post;

  @Input('isFirst') isFirst : boolean;
  @Input('isLast') isLast : boolean;
  @Output('update') update : EventEmitter<null> = new EventEmitter();
  
  @Output('up') up : EventEmitter<Post> = new EventEmitter();
  @Output('down') down : EventEmitter<Post> = new EventEmitter<Post>();
 
  @Output('left') left : EventEmitter<Post> = new EventEmitter<Post>();
  @Output('right') right : EventEmitter<Post> = new EventEmitter<Post>();


  constructor(private iconsLibrary: NbIconLibraries, 
    private  postService : PostService) { 
    iconsLibrary.registerFontPack('fa', { packClass: 'fa', iconClassPrefix: 'fa' });
    iconsLibrary.registerFontPack('far', { packClass: 'far', iconClassPrefix: 'fa' });
  }

 

  deletePost(post: Post) {
     this.postService.delete(post.id).pipe(takeWhile(() => this.alive)).subscribe(_ =>  this.update.emit(null) );
  }

  downPost() 
  {
    this.down.emit(this.item);
  }

  upPost() 
  {
    this.up.emit(this.item);
  }

  leftPost() 
  {
    this.left.emit(this.item);
  }

  rightPost() 
  {
    this.right.emit(this.item);
  }

  ngOnInit() {
  }

  ngOnDestroy(): void {
    this.alive = false;
  }
}
