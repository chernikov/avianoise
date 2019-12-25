import { Routes } from '@angular/router';
import { AdminComponent } from './containers/admin.component';
import { AddAirportComponent } from './containers/_components/add-airport/add-airport.component';

export const router: Routes = [
    { path: '', component: AdminComponent , children: 
        [
            { path: 'add-airport', component: AddAirportComponent }
        ] 
    },
]