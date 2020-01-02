import { Routes } from '@angular/router';
import { AdminComponent } from './containers/admin.component';
import { EditAirportComponent } from './_components/edit-airport/edit-airport.component';
import { AirportComponent } from './_components/airport/airport.component';
import { AirportListComponent } from './_components/airport-list/airport-list.component';

export const router: Routes = [
    { path: '', component: AdminComponent , children: 
        [
            { path: 'airport/edit/:id', component: EditAirportComponent },
            { path: 'airport/add', component: EditAirportComponent },
            { path: 'airport', component: AirportListComponent },
            { path: 'airport/:id', component: AirportComponent }
        ] 
    },
]