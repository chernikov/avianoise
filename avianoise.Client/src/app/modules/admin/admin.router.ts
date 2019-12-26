import { Routes } from '@angular/router';
import { AdminComponent } from './containers/admin.component';
import { EditAirportComponent } from './containers/_components/edit-airport/edit-airport.component';

export const router: Routes = [
    { path: '', component: AdminComponent , children: 
        [
            { path: 'edit-airport', component: EditAirportComponent }
        ] 
    },
]