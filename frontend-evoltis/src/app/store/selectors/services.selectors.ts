import { createSelector } from "@ngrx/store";
import { AppState } from "../states/app.state";

export const selectServicesFeature = (state: AppState) => state.services;
export const selectServices = createSelector(selectServicesFeature, (state) => state.services);
export const selectService = createSelector(selectServicesFeature, (state) => state.service);
export const selectServicesLoading = createSelector(selectServicesFeature, (state) => state.loading);
export const selectServicesAdded = createSelector(selectServicesFeature, (state) => state.added);
export const selectServicesModified = createSelector(selectServicesFeature, (state) => state.modified);
export const selectServicesDeleted = createSelector(selectServicesFeature, (state) => state.deleted);