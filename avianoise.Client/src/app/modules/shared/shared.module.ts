import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgmCoreModule } from '@agm/core';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCdcXxwWC9ritIfQ1f8QDocDtwd1oxG8-w'
    }),
  ],
  exports : [
    AgmCoreModule
  ]
})
export class SharedModule { }
