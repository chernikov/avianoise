import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginComponent } from './containers/login.component';
import { RouterModule } from '@angular/router';
import { router } from './index.router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NbSpinnerModule, NbButtonModule, NbInputModule, NbLayoutModule, NbCheckboxModule, NbSidebarModule, NbIconModule } from '@nebular/theme';
import { MapComponent } from './containers/map.component';

@NgModule({
  declarations: [LoginComponent, MapComponent],
  imports: [
    NbSpinnerModule,
    NbLayoutModule,
    NbButtonModule,
    NbInputModule,
    NbCheckboxModule,
    CommonModule,
    RouterModule.forChild(router),
    FormsModule,
    ReactiveFormsModule
  ]
})
export class IndexModule { }
