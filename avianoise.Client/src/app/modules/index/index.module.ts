import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxSmartModalModule } from 'ngx-smart-modal';
import { MatFormFieldModule, MatInputModule } from '@angular/material';

import { LoginComponent } from './containers/login.component';
import { RouterModule } from '@angular/router';
import { router } from './index.router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NbSpinnerModule, NbButtonModule, NbInputModule, NbLayoutModule, NbCheckboxModule } from '@nebular/theme';
import { MapComponent } from './containers/map.component';
import { CallbackModalComponent } from './containers/_components/callback-modal/callback-modal.component';
import { FileUploadModule } from 'ng2-file-upload';
import { FileFormatPipe } from '@pipes/file-format.pipe';
import { FileSizePipe } from '@pipes/file-size.pipe';
import { ToastComponent } from './containers/_components/toast/toast.component';
import { PostComponent } from './containers/_components/post/post.component';
import { SanitizeHtmlPipe } from '@pipes/sanitize-html.pipe';

@NgModule({
  declarations: [LoginComponent, MapComponent, CallbackModalComponent, FileFormatPipe, FileSizePipe, ToastComponent, PostComponent, SanitizeHtmlPipe],
  imports: [
    MatFormFieldModule,
    MatInputModule,
    NbSpinnerModule,
    NbLayoutModule,
    NbButtonModule,
    NbInputModule,
    NbCheckboxModule,
    CommonModule,
    RouterModule.forChild(router),
    FormsModule,
    ReactiveFormsModule,
    NgxSmartModalModule.forRoot(),
    FileUploadModule
  ]
})
export class IndexModule { }
