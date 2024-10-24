import { createSelector } from "@ngrx/store";
import { AppState } from "../states/app.state";

export const selectClientFeature = (state: AppState) => state.clients;

export const selectClient = createSelector(selectClientFeature, (state) => state.client)
export const selectClients = createSelector(selectClientFeature, (state) => state.clients)
export const selectClientsLoading = createSelector(selectClientFeature, (state) => state.loading)
export const selectClientsAdded = createSelector(selectClientFeature, (state) => state.added)
export const selectClientsModified = createSelector(selectClientFeature, (state) => state.modified)
export const selectClientsDeleted = createSelector(selectClientFeature, (state) => state.deleted)