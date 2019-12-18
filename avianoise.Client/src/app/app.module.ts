import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { routes } from './app.router';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { MaterialModule } from '@shared/material.module';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
import { NgtUniversalModule } from '@ng-toolkit/universal';

import { AuthEffects } from './state/auth.effects';
import * as fromAuthReducer from './state/auth.reducer';

import { environment } from '../environments/environment';
import { JWT_Module_Options } from './config/jwt-options.config';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    routes,
    BrowserAnimationsModule,
    NgtUniversalModule,
    MaterialModule,
    StoreModule.forRoot({auth: fromAuthReducer.reducer}),
    StoreDevtoolsModule.instrument({
      name: 'avianoise',
      maxAge: 25,
      logOnly: environment.production
    }),
    EffectsModule.forRoot([AuthEffects]),
    JwtModule.forRoot(JWT_Module_Options)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
