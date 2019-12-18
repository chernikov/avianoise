import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistrationComponent } from './containers/registration.component';
//import { MaterialModule } from '@shared/material.module';
import { RouterModule } from '@angular/router';
import { router } from './index.router';


@NgModule({
  declarations: [RegistrationComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(router)

  ]
})
export class IndexModule { }
