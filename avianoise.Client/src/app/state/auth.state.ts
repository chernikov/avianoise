import * as fromRoot from './app.state';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AuthState } from './auth.reducer';

const getAuthState = createFeatureSelector<AuthState>('auth');

export const getToken = createSelector(
    getAuthState,
    state => state.token
);

export const getUserRoles = createSelector(
    getAuthState,
    state => state.user.roles
);

export const getUser = createSelector(
    getAuthState,
    state => state.user
);