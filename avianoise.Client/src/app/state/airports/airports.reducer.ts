import { Airport } from '@classes/airport.class';
import { AirportActions, AirportsActionsTypes } from './airports.actions';

export interface AirportsState {
    airports: Airport[];
    selectedAirport: Airport;
}

const initialAirportsState: AirportsState = {
    airports: [],
    selectedAirport: null
}

export function reducer(state = initialAirportsState, action: AirportActions): AirportsState
{
    switch(action.type)
    {
        case AirportsActionsTypes.GetAllAirports :
            return { ...state }
        case AirportsActionsTypes.GetAllAirportsSuccess :
            return { ...state,
            airports: action.payload
            }
        case AirportsActionsTypes.AddAirport :
            return { ...state,
                selectedAirport: action.payload
            }
        case AirportsActionsTypes.ChangeAirport :
            return { ...state,
                selectedAirport: action.payload
            }
        case AirportsActionsTypes.DeleteAirport :
            return { ...state,
                selectedAirport: action.payload
            }
        default: 
            return state;
    }
}