import { Component, OnInit, OnDestroy } from '@angular/core';

import { PostService } from '@services/post.service';
import { Post } from '@classes/post.class';
import { takeWhile } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

import * as Base64UploadAdapter from '@ckeditor/ckeditor5-upload/src/adapters/base64uploadadapter';


@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.scss']
})
export class EditPostComponent implements OnInit, OnDestroy {

  Editor = ClassicEditor;

  config = {
    // removePlugins : ["CKFinderUploadAdapter"],
    // plugins: [ Base64UploadAdapter ]
  }

  alive: boolean = true;

  post: Post;
  content: string = "";
  title: string = "";
  isPublished: boolean = false;
  formInProgress: boolean;

  constructor(
    private postService: PostService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.getPost();
  }

  onReady(editor) 
  {
     debugger;
    // console.log(editor);
    // console.log(this.Editor.builtinPlugins.map(p => p.pluginName));

    
     let repository = editor.plugins.get('FileRepository');
     repository.createUploadAdapter = (loader) => {
      console.log(btoa(loader.file));
      return new Base64UploadAdapter(loader); 
     };


    // // module.clear();
    // // module.createUploadAdapter = (loader) => {
    // //     console.log(btoa(loader.file));
    // //     return new Base64UploadAdapter(loader); // UploadAdapter(loader);
    // // };
    // // tslint:disable-next-line:max-line-length
    // // Only useful source: https://stackoverflow.com/questions/52052514/upload-adapter-is-not-defined-issue-with-image-uploading-in-ckeditor5-angular/55237874#55237874
    // editor.plugins.get('FileRepository').createUploadAdapter = (loader) => {
    //   console.log(btoa(loader.file));
    //   return new Base64UploadAdapter(loader); // UploadAdapter(loader);
    // };
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
