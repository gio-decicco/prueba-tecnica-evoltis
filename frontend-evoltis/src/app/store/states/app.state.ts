import { ActionReducerMap } from "@ngrx/store";
import { ClientState } from "./clients.state";
import { clientsReducer } from "../reducers/clients.reducer";
import { ServicesState } from "./services.state";
import { servicesReducer } from "../reducers/services.reducer";

export interface AppState {
    clients: ClientState,
    services: ServicesState
}

export const ROOT_REDUCERS: ActionReducerMap<AppState> = {
    clients: clientsReducer,
    services: servicesReducer
}