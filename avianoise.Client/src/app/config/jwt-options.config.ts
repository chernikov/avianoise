import { JwtModuleOptions } from "@auth0/angular-jwt";
import { applicationOptions } from './options';

export function jwtTokenGetter() {
    return localStorage.getItem(applicationOptions.authTokenName);
}

export const JWT_Module_Options: JwtModuleOptions = {
    config: {
        tokenGetter: jwtTokenGetter,
    }
};