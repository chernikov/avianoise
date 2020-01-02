import { AuthActions, AuthActionTypes } from './auth.actions';
import { User } from '@classes/user.class';
import { Role } from '@classes/role.class';

export interface AuthState {
    token: null | string;
    user: User;
    role: Role;
    error: null | string;
}

const initialAuthState: AuthState = {
    token: null,
    user: null,
    role: null,
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
        case AuthActionTypes.PopulateRole :
            return { ...state, 
                role: action.payload
            }
        case AuthActionTypes.ClearAuthStorage :
            return { ...state,
                user: null,
                role: null,
                token: null
            }
        default:
            return state;
    }   

}