import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorGuard } from './guards/author.guard';


export const router: Routes = [
    { path: 'admin', canActivate: [AuthorGuard], loadChildren: './modules/admin/admin.module#AdminModule' },
    { path: '', loadChildren: './modules/index/index.module#IndexModule' },
    { path: '**', redirectTo: '', pathMatch: 'full' }
]

export const routes: ModuleWithProviders = RouterModule.forRoot(router);