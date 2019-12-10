import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestComponent } from './test/test.component';
import { IndexComponent } from './index/index.component';


export const router: Routes = [
    { path: '', component : TestComponent },
    { path: 'test', component : IndexComponent  },
]

export const routes: ModuleWithProviders = RouterModule.forChild(router);