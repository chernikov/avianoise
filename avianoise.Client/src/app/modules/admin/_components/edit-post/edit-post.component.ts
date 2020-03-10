import { Component, OnInit, OnDestroy } from '@angular/core';


import { PostService } from '@services/post.service';
import { Post } from '@classes/post.class';
import { takeWhile } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
//Quill.register('modules/imageResize', ImageResize);

interface Quill {
  getModule(moduleName: string);
}

interface BetterTableModule {
  insertTable(rows: number, columns: number): void;
}

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.scss']
})
export class EditPostComponent implements OnInit, OnDestroy {
  alive: boolean = true;

  public quill: Quill;
  post: Post;
  content: string = "";
  title: string = "";
  isPublished: boolean = false;
  formInProgress: boolean;

  editorOptions = {
    toolbar: {
      container: [
        [{ 'size': ['small', false, 'large', 'huge'] }],
        ['bold', 'italic', 'underline', 'strike'],
        [{ 'header': 1 }, { 'header': 2 }],
        [{ 'color': [] }, { 'background': [] }],
        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
        [{ 'align': [] }],
        ['link', 'image']
      ]
    }
  };

  constructor(
    private postService: PostService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.getPost();
  }

  getPost() {
    this.route.params.subscribe(param => {
      if(param.id) {
        this.postService.get(param.id).pipe(takeWhile(() => this.alive)).subscribe(post => {
          this.post = post;
          this.content = post.text;
          this.title = post.title;
          this.isPublished = post.isPublished;
        });
      }
    })
  }

  private get tableModule(): BetterTableModule {
    return this.quill.getModule("better-table");
  }

  public editorCreated(event: Quill): void {
    this.quill = event;
    // Example on how to add new table to editor
    this.addNewtable();
  }

  private addNewtable(): void {
    this.tableModule.insertTable(3, 3);
  }

  onSave() {
    this.formInProgress = true;
    let data = this.collectData();
    if(this.post) {
      this.postService.put(data).pipe(takeWhile(() => this.alive)).subscribe(_ => {
        this.router.navigateByUrl('/admin/post');
        this.formInProgress = false;
      });
    } else {
      this.postService.post(data).pipe(takeWhile(() => this.alive)).subscribe(_ => {
        this.router.navigateByUrl('/admin/post');
        this.formInProgress = false;
      });
    }
    
  }

  collectData() : Post {
    let data: Post = {
      id: null,
      order : 0,
      postId : null,
      text: this.content,
      title: this.title,
      addedDate: null,
      isPublished: this.isPublished,
      posts : null
    }
    if(this.post) {
      data.addedDate = this.post.addedDate;
      data.id = this.post.id;
      data.postId = this.post.postId;
      data.order = this.post.order;
    }
    return data;
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
