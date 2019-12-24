import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AirportsState } from './airports.reducer';

const getAirportsState = createFeatureSelector<AirportsState>('airports');

export const getAirports = createSelector(
    getAirportsState,
    state => state.airports
);

export const getSelectedAirport = createSelector(
    getAirportsState,
    state => state.selectedAirport
);
