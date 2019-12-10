import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


export const router: Routes = [
    { path: '', loadChildren: './default/default.module#DefaultModule' },
    { path: '**', redirectTo: '' }
]

export const routes: ModuleWithProviders = RouterModule.forRoot(router);