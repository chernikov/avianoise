import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorGuard } from './guards/author.guard';


export const router: Routes = [
    { path: '', redirectTo: '/registration', pathMatch: 'full' },
    { path: 'registration', loadChildren: './modules/index/index.module#IndexModule' },
    { path: 'test', canActivate: [AuthorGuard], canLoad: [AuthorGuard], canActivateChild: [AuthorGuard], loadChildren: './modules/test/test.module#TestModule' },
    { path: '**', redirectTo: '/registration', pathMatch: 'full' }
]

export const routes: ModuleWithProviders = RouterModule.forRoot(router);