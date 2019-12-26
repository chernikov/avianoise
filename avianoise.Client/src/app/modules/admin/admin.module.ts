import { NgModule } from "@angular/core";
import { AdminComponent } from './containers/admin.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { router } from './admin.router';
import { AgmCoreModule } from '@agm/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@shared/material.module';
import { EditAirportComponent } from './containers/_components/edit-airport/edit-airport.component';

@NgModule({
    declarations: [AdminComponent, EditAirportComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule,
        RouterModule.forChild(router),
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyCdcXxwWC9ritIfQ1f8QDocDtwd1oxG8-w'
        })
    ]
})
export class AdminModule { }