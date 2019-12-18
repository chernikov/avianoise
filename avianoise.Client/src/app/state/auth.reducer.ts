import { AuthActions, AuthActionTypes } from './auth.actions';

export interface AuthState {
    token: null | string;
    error: null | string;
}

const initialAuthState: AuthState = {
    token: null,
    error: ''
}

export function reducer(state = initialAuthState, action: AuthActions): AuthState
{
    switch(action.type)
    {
        case AuthActionTypes.LoadTokenFromLocalStorageSuccess :
            return { ...state,
                token: action.payload,
                error: null,
            }
        case AuthActionTypes.SaveTokenToLocalStorage :
            return { ...state,
                token: action.payload,
                error: null    
            }
        case AuthActionTypes.LoadTokenFromLocalStorageFail :
            return { ...state,
                token: action.payload,
                error: null
            }
        case AuthActionTypes.ClearAuthStorage :
            return { ...state,
                token: null
            }
        default:
            return state;
    }   

}