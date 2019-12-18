import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


export const router: Routes = [
    { path: '', redirectTo: '/registration', pathMatch: 'full' },
    { path: 'registration', loadChildren: './modules/index/index.module#IndexModule' },
    { path: 'test', loadChildren: './modules/test/test.module#TestModule' },
    { path: '**', redirectTo: '/registration', pathMatch: 'full' }
]

export const routes: ModuleWithProviders = RouterModule.forRoot(router);