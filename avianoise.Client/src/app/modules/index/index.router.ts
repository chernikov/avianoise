import { Routes } from '@angular/router';
import { LoginComponent } from './containers/login.component';
import { MapComponent } from './containers/map.component';


export const router: Routes = [
    { path: '', component: MapComponent },
    { path: 'login', component: LoginComponent },
    { path: 'map', component: MapComponent },
    { path: 'post/:id', component: MapComponent },
    { path: '**', redirectTo: '', pathMatch: 'full' }
]