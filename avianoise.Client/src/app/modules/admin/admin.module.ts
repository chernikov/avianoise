import { NgModule } from "@angular/core";
import { AdminComponent } from './containers/admin.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { router } from './admin.router';

@NgModule({
    declarations: [AdminComponent],
    imports: [
        CommonModule,
        RouterModule.forChild(router)
    ]
})
export class AdminModule { }