import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NumberToArrayPipe } from '@pipes/number-to-array.pipe';
import { NbMenuModule, NbButtonModule, NbCardModule, NbListModule, NbInputModule, NbTabsetModule, NbCheckboxModule, NbLayoutModule, NbAccordionModule, NbSpinnerModule, NbToggleModule, NbWindowModule, NbRadioModule, NbIconModule } from '@nebular/theme';

import { FileUploadModule } from 'ng2-file-upload';
import { NgxPaginationModule } from 'ngx-pagination';
import { SharedModule } from '../shared/shared.module';
import { ThemeModule } from 'src/app/@theme/theme.module';

import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { router } from './admin.router';

import { EditAirportComponent } from './_components/edit-airport/edit-airport.component';
import { AirportComponent } from './_components/airport/airport.component';
import { AirportListComponent } from './_components/airport-list/airport-list.component';
import { AdminComponent } from './containers/admin.component';
import { PostListComponent } from './_components/post-list/post-list.component';
import { EditPostComponent } from './_components/edit-post/edit-post.component';
import { PostItemComponent } from './_components/post-item/post-item.component';
import { FeedbacksComponent } from './_components/feedback/feedback.component';

@NgModule({
    declarations: [AdminComponent, EditAirportComponent, AirportComponent, AirportListComponent, FeedbacksComponent, NumberToArrayPipe, PostListComponent, EditPostComponent, PostItemComponent],
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
        CKEditorModule
    ]
})
export class AdminModule { }