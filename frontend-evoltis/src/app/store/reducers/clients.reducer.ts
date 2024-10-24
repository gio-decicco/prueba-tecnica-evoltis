import { createReducer, on } from "@ngrx/store";
import { ClientState } from "../states/clients.state";
import { deleteClient, deleteClientError, deleteClientSuccess, getClientById, getClientByIdError, getClientByIdSuccess, getClients, getClientsError, getClientsSuccess, modifyClient, modifyClientError, modifyClientSuccess, postClient, postClientError, postClientSuccess } from "../actions/clients.actions";

export const initialState: ClientState = {
    client: null,
    clients: [],
    loading: false,
    added: false,
    modified: false,
    deleted: false
}

export const clientsReducer = createReducer(
    initialState,

    on(postClient, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(postClientSuccess, (state, { client }) => {
        return {
            ...state,
            loading: false,
            client: client,
            added: true
        }
    }),
    on(postClientError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),

    on(getClientById, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(getClientByIdSuccess, (state, { client }) => {
        return {
            ...state,
            loading: false,
            client
        }
    }),
    on(getClientByIdError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),

    on(getClients, (state) => {
        return {
            ...state,   
            loading: true
        }
    }),
    on(getClientsSuccess, (state, { clients }) => {    
        return {
            ...state,
            loading: false,
            clients
        }
    }),
    on(getClientsError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),

    on(modifyClient, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(modifyClientSuccess, (state, { client }) => {
        return {
            ...state,
            loading: false,
            client,
            modified: true
        }
    }),
    on(modifyClientError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),

    on(deleteClient, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(deleteClientSuccess, (state, { client }) => {
        return {
            ...state,
            loading: false,
            client,
            deleted: true
        }
    }),
    on(deleteClientError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),
)