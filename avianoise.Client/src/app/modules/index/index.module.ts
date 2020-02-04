import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginComponent } from './containers/login.component';
import { RouterModule } from '@angular/router';
import { router } from './index.router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NbButtonModule, NbInputModule, NbLayoutModule, NbCheckboxModule } from '@nebular/theme';
import { MapComponent } from './containers/map.component';

@NgModule({
  declarations: [LoginComponent, MapComponent],
  imports: [
    NbLayoutModule,
    NbButtonModule,
    NbInputModule,
    NbCheckboxModule,
    CommonModule,
    RouterModule.forChild(router),
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class IndexModule { }
