import { NgModule } from "@angular/core";
import { AdminComponent } from './containers/admin.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { router } from './admin.router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditAirportComponent } from './_components/edit-airport/edit-airport.component';
import { AirportComponent } from './_components/airport/airport.component';
import { AirportListComponent } from './_components/airport-list/airport-list.component';
import { FileUploadModule } from 'ng2-file-upload';
import { SharedModule } from '../shared/shared.module';

import { ThemeModule } from 'src/app/@theme/theme.module';
import { NbMenuModule, NbButtonModule, NbCardModule, NbListModule, NbInputModule, NbTabsetModule, NbCheckboxModule, NbLayoutModule, NbAccordionModule, NbSpinnerModule, NbToggleModule, NbWindowModule, NbRadioModule } from '@nebular/theme';



@NgModule({
    declarations: [AdminComponent, EditAirportComponent, AirportComponent, AirportListComponent],
    imports: [
        SharedModule,
        ThemeModule,
        NbWindowModule.forChild(),
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
        RouterModule.forChild(router),
        
        FileUploadModule
    ]
})
export class AdminModule { }