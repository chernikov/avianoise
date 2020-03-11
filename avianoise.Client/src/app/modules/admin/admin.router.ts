import { Routes } from '@angular/router';
import { AdminComponent } from './containers/admin.component';
import { EditAirportComponent } from './_components/edit-airport/edit-airport.component';
import { AirportComponent } from './_components/airport/airport.component';
import { AirportListComponent } from './_components/airport-list/airport-list.component';
import { FeedbacksComponent } from './_components/feedback/feedback.component';
import { PostListComponent } from './_components/post-list/post-list.component';
import { EditPostComponent } from './_components/edit-post/edit-post.component';
import { PracticeListComponent } from './_components/practice-list/practice-list.component';
import { EditPracticeComponent } from './_components/edit-practice/edit-practice.component';

export const router: Routes = [
    { path: '', component: AdminComponent , children: 
        [
            { path: 'airport/edit/:id', component: EditAirportComponent },
            { path: 'airport/add', component: EditAirportComponent },
            { path: 'airport', component: AirportListComponent },
            { path: 'airport/:id', component: AirportComponent },
            { path: 'feedbacks', component: FeedbacksComponent },
            { path: 'post', component: PostListComponent },
            { path: 'post/add', component: EditPostComponent },
            { path: 'post/edit/:id', component: EditPostComponent },
            { path: 'practice', component: PracticeListComponent },
            { path: 'practice/add', component: EditPracticeComponent },
            { path: 'practice/edit/:id', component: EditPracticeComponent }
        ] 
    },
]