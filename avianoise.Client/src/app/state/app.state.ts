import { AuthState } from './auth/auth.reducer';

export interface State {
    some: string,
    auth: AuthState,
    airports: AuthState
}