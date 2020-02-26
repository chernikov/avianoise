import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NumberToArrayPipe } from '@pipes/number-to-array.pipe';

import { QuillModule } from 'ngx-quill';

import { FileUploadModule } from 'ng2-file-upload';
import { NgxPaginationModule } from 'ngx-pagination';


import { router } from './admin.router';
import { EditAirportComponent } from './_components/edit-airport/edit-airport.component';
import { AirportComponent } from './_components/airport/airport.component';
import { AirportListComponent } from './_components/airport-list/airport-list.component';
import { SharedModule } from '../shared/shared.module';
import { ThemeModule } from 'src/app/@theme/theme.module';
import { NbMenuModule, NbButtonModule, NbCardModule, NbListModule, NbInputModule, NbTabsetModule, NbCheckboxModule, NbLayoutModule, NbAccordionModule, NbSpinnerModule, NbToggleModule, NbWindowModule, NbRadioModule, NbIconModule } from '@nebular/theme';
import { FeedbacksComponent } from './_components/feedback/feedback.component';


import { AdminComponent } from './containers/admin.component';
import { PostListComponent } from './_components/post-list/post-list.component';
import { EditPostComponent } from './_components/edit-post/edit-post.component';
@NgModule({
    declarations: [AdminComponent, EditAirportComponent, AirportComponent, AirportListComponent, FeedbacksComponent, NumberToArrayPipe, PostListComponent, EditPostComponent],
    imports: [
        SharedModule,
        ThemeModule,
        NbIconModule,
        NbLayoutModule,
        NbToggleModule,
        NbRadioModule,
        NbAccordionModule,
        NbMenuModule,
        NbTabsetModule,
        NbButtonModule,
        NbCardModule,
        NbListModule,
        NbInputModule,
        NbCheckboxModule,
        NbSpinnerModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NgxPaginationModule,
        FileUploadModule,
        NbWindowModule.forChild(),
        RouterModule.forChild(router),
        QuillModule.forRoot()
    ]
})
export class AdminModule { }