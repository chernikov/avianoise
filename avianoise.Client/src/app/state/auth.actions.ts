import { Action } from '@ngrx/store';
import { User } from '@classes/user.class';

export enum AuthActionTypes {
    GetTokenFromLocalStorage = '[Auth] Get token from localStorage',
    LoadTokenFromLocalStorageSuccess = '[Auth] Load token from localStorage success',
    LoadTokenFromLocalStorageFail = '[Auth] Load token from localStorage fail',
    PopulateUser = '[Auth] Pupulate User from Auth token',
    SaveTokenToLocalStorage = '[Auth] Save token to localStorage',
    ClearAuthStorage = '[Auth] Clear Auth'
}

export class GetTokenFromLocalStorage implements Action {
    readonly type = AuthActionTypes.GetTokenFromLocalStorage;
}

export class LoadTokenFromLocalStorageSuccess implements Action {
    readonly type = AuthActionTypes.LoadTokenFromLocalStorageSuccess;
    constructor(public payload: string) { }
}

export class LoadTokenFromLocalStorageFail implements Action {
    readonly type = AuthActionTypes.LoadTokenFromLocalStorageFail;
    constructor(public payload: string) { }
}

export class PopulateUser implements Action {
    readonly type = AuthActionTypes.PopulateUser;
    constructor(public payload: User) { }
}

export class SaveTokenToLocalStorage implements Action {
    readonly type = AuthActionTypes.SaveTokenToLocalStorage;
    constructor(public payload: string) { }
}

export class ClearAuthStorage implements Action {
    readonly type = AuthActionTypes.ClearAuthStorage;
}

export type AuthActions = 
    GetTokenFromLocalStorage |
    LoadTokenFromLocalStorageSuccess |
    LoadTokenFromLocalStorageFail |
    SaveTokenToLocalStorage |
    PopulateUser |
    ClearAuthStorage;