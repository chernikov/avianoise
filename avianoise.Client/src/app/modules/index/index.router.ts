import { Routes } from '@angular/router';
import { LoginComponent } from './containers/login.component';
import { MapComponent } from './containers/map.component';
import { PostComponent } from './containers/_components/post/post.component';


export const router: Routes = [
    { path: '', component: MapComponent },
    { path: 'login', component: LoginComponent },
    { path: 'map', component: MapComponent },
    { path: 'post/:id', component: PostComponent },
    { path: '**', redirectTo: '', pathMatch: 'full' }
]