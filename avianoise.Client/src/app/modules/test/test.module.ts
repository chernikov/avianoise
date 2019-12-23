import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';

import { TestComponent } from './containers/test.component';

import { RouterModule } from '@angular/router';
import { router } from './test.router';

@NgModule({
    declarations: [TestComponent],
    imports: [
        CommonModule,
        RouterModule.forChild(router)
    ]
})
export class TestModule { }