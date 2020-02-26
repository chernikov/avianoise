import { Component } from '@angular/core';

import { NbMenuItem } from '@nebular/theme';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  menu: NbMenuItem[];
  constructor( ) {
    this.menu = [
      {
        title: 'Аеропорти',
        link: '/admin/airport/',
        icon: 'home-outline'
      },
      {
        title: "Зворотній зв'язок",
        link: '/admin/feedbacks/',
        icon: 'phone-outline'
      },
      {
        title: "Новини",
        link: '/admin/post/',
        icon: 'book-open-outline'
      }
    ]
  }
}
