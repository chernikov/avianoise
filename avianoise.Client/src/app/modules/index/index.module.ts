import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistrationComponent } from './containers/registration.component';
//import { MaterialModule } from '@shared/material.module';
import { RouterModule } from '@angular/router';
import { router } from './index.router';
import { MaterialModule } from '@shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [RegistrationComponent],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule.forChild(router),
    FormsModule,
    ReactiveFormsModule
  ]
})
export class IndexModule { }
