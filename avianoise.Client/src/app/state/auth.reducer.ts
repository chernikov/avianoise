import { AuthActions, AuthActionTypes } from './auth.actions';
import { User } from '@classes/user.class';

export interface AuthState {
    token: null | string;
    user: User;
    error: null | string;
}

const initialAuthState: AuthState = {
    token: null,
    user: null,
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
        case AuthActionTypes.PopulateUser :
            return { ...state,
                user: action.payload
            }
        case AuthActionTypes.ClearAuthStorage :
            return { ...state,
                user: null,
                token: null
            }
        default:
            return state;
    }   

}