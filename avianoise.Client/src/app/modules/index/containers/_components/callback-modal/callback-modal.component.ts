import { Component, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FileUploader } from 'ng2-file-upload';
import { FeedbackFile } from '@classes/feedback-file.class';
import { FeedbackService } from '@services/feedback.service';
import { Feedback } from '@classes/feedback.class';
import { takeWhile, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-callback-modal',
  templateUrl: './callback-modal.component.html',
  styleUrls: ['./callback-modal.component.scss']
})
export class CallbackModalComponent implements OnInit, OnDestroy {
  @Output() showToast = new EventEmitter<number>();

  alive: boolean = true;
  form: FormGroup;
  formInProgress: boolean;
  uploader: FileUploader;
  files: FeedbackFile[];

  constructor(
    private modalService: NgxSmartModalService,
    private formBuilder: FormBuilder,
    private feedbackService: FeedbackService
  ) {
    this.files = [];
  }

  ngOnInit() {
    this.initForm();
    this.createUploader();
  }

  initForm() {
    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      message: ['', Validators.required],
      privacyPolicy: [false, Validators.requiredTrue]
    });
  }

  createUploader() {
    this.uploader = new FileUploader({
      headers: [{name:'Accept', value:'application/json'}],
      url: 'api/feedback-file',
      maxFileSize: 5242880
    });

    this.uploader.onCompleteItem = (item: any, response: any)=>  {
      let files: FeedbackFile[] = JSON.parse(response);
      files.map(item => {
        this.files.push(item);
      });
    };
  }

  close() {
    this.modalService.getModal('callbackModal').close();
  }

  removeFile(fileObject) {
    this.uploader.queue = this.uploader.queue.filter(queueFile => queueFile != fileObject);
    this.files = this.files.filter(item => item.name != fileObject.file.name);
  }

  collectFeedback(): Feedback {
    let feedback: Feedback = {
      id: null,
      addedDate: null,
      name: this.form.value.name,
      email: this.form.value.email,
      message: this.form.value.message,
      feedbackFiles: this.files 
    }
    return feedback;
  }

  clearForm() {
    this.form.reset();
    this.uploader.queue = [];
  }

  sendForm() {
    let feedBack = this.collectFeedback();
    this.formInProgress = true;
    this.feedbackService.post(feedBack).pipe(takeWhile(() => this.alive)).subscribe(_ => {
        this.formInProgress = false;
        this.modalService.getModal('callbackModal').close();
        this.clearForm();
        this.showToast.emit(1);
    }, err => {
      this.showToast.emit(2);
      this.formInProgress = false;
    });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
