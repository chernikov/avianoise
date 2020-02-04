import { Routes } from '@angular/router';
import { LoginComponent } from './containers/login.component';
import { MapComponent } from './containers/map.component';


export const router: Routes = [
    { path: '', component: LoginComponent },
    { path: 'login', component: LoginComponent },
    { path: 'map', component: MapComponent },
]