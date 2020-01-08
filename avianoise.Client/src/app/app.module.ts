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

import { AuthEffects } from '@state/auth/auth.effects';
import { AirportsEffects } from '@state/airports/airports.effects';
import * as fromAuthReducer from '@state/auth/auth.reducer';
import * as fromAirportsReducer from '@state/airports/airports.reducer';

import { environment } from '../environments/environment';
import { JWT_Module_Options } from './config/jwt-options.config';
import { AuthorGuard } from './guards/author.guard';
import { ThemeModule } from './@theme/theme.module';
import { NbMenuModule, NbSidebarModule } from '@nebular/theme';
import { CoreModule } from './@core/core.module';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ThemeModule.forRoot(),
    NbMenuModule.forRoot(),
    NbSidebarModule.forRoot(),
    CoreModule.forRoot(),
    HttpClientModule,
    routes,
    BrowserAnimationsModule,
    NgtUniversalModule,
    MaterialModule,
    StoreModule.forRoot({
      auth: fromAuthReducer.reducer,
      airports: fromAirportsReducer.reducer
    }),
    StoreDevtoolsModule.instrument({
      name: 'avianoise',
      maxAge: 25,
      logOnly: environment.production
    }),
    EffectsModule.forRoot([AuthEffects, AirportsEffects]),
    JwtModule.forRoot(JWT_Module_Options)
  ],
  providers: [
    AuthorGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
