import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginComponent } from './containers/login.component';
import { RouterModule } from '@angular/router';
import { router } from './index.router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NbButtonModule, NbInputModule, NbLayoutModule } from '@nebular/theme';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    NbLayoutModule,
    NbButtonModule,
    NbInputModule,
    CommonModule,
    RouterModule.forChild(router),
    FormsModule,
    ReactiveFormsModule
  ]
})
export class IndexModule { }
