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
import { FileFormatPipe } from 'src/app/models/pipes/file-format.pipe';
import { FileSizePipe } from 'src/app/models/pipes/file-size.pipe';

@NgModule({
  declarations: [LoginComponent, MapComponent, CallbackModalComponent, FileFormatPipe, FileSizePipe],
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
