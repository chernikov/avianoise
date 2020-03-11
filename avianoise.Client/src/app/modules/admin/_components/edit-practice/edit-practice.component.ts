import { Component, OnInit, OnDestroy } from '@angular/core';

import { PracticeService } from '@services/practice.service';
import { Practice } from '@classes/practice.class';
import { takeWhile } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

import * as AviaEditor from '../../../../../ckeditor/ckeditor';


@Component({
  selector: 'app-edit-practice',
  templateUrl: './edit-practice.component.html',
  styleUrls: ['./edit-practice.component.scss']
})
export class EditPracticeComponent implements OnInit, OnDestroy {

  Editor = AviaEditor;

  alive: boolean = true;

  practice: Practice;
  content: string = "";
  title: string = "";
  isPublished: boolean = false;
  formInProgress: boolean;

  constructor(
    private practiceService: PracticeService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.getPractice();
  }

  getPractice() {
    this.route.params.subscribe(param => {
      if(param.id) {
        this.practiceService.get(param.id).pipe(takeWhile(() => this.alive)).subscribe(practice => {
          this.practice = practice;
          this.content = practice.text;
          this.title = practice.title;
          this.isPublished = practice.isPublished;
        });
      }
    })
  }

  onSave() {
    this.formInProgress = true;
    let data = this.collectData();
    if(this.practice) {
      this.practiceService.put(data).pipe(takeWhile(() => this.alive)).subscribe(_ => {
        this.router.navigateByUrl('/admin/practice');
        this.formInProgress = false;
      });
    } else {
      this.practiceService.post(data).pipe(takeWhile(() => this.alive)).subscribe(_ => {
        this.router.navigateByUrl('/admin/practice');
        this.formInProgress = false;
      });
    }
    
  }

  collectData() : Practice {
    let data: Practice = {
      id: null,
      order : 0,
      practiceId : null,
      text: this.content,
      title: this.title,
      addedDate: null,
      isPublished: this.isPublished,
      practices : null
    }
    if(this.practice) {
      data.addedDate = this.practice.addedDate;
      data.id = this.practice.id;
      data.practiceId = this.practice.practiceId;
      data.order = this.practice.order;
    }
    return data;
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
