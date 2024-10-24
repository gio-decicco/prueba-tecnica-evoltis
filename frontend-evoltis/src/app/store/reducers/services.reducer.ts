import { createReducer, on } from "@ngrx/store";
import { postService, postServiceSuccess, postServiceError, getServiceById, getServiceByIdSuccess, getServiceByIdError, getServices, getServicesSuccess, getServicesError, modifyService, modifyServiceSuccess, modifyServiceError, deleteService, deleteServiceSuccess, deleteServiceError } from "../actions/services.actions";
import { ServicesState } from "../states/services.state";

export const initialState: ServicesState = {
    service: null,
    services: [],
    loading: false,
    added: false,
    modified: false,
    deleted: false
}


export const servicesReducer = createReducer(
    initialState,

    on(postService, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(postServiceSuccess, (state, { service }) => {
        return {
            ...state,
            loading: false,
            service: service,
            added: true
        }
    }),
    on(postServiceError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),

    on(getServiceById, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(getServiceByIdSuccess, (state, { service }) => {
        return {
            ...state,
            loading: false,
            service: service
        }
    }),
    on(getServiceByIdError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),

    on(getServices, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(getServicesSuccess, (state, { services }) => {
        return {
            ...state,
            loading: false,
            services
        }    
    }),
    on(getServicesError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),

    on(modifyService, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(modifyServiceSuccess, (state, { service }) => {
        return {
            ...state,
            loading: false,
            service,
            modified: true
        }
    }),
    on(modifyServiceError, (state) => {
        return {
            ...state,
            loading: false
        }
    }),

    on(deleteService, (state) => {
        return {
            ...state,
            loading: true
        }
    }),
    on(deleteServiceSuccess, (state, { service }) => {
        return {
            ...state,
            loading: false,
            service,
            deleted: true
        }
    }),
    on(deleteServiceError, (state) => {
        return {
            ...state,
            loading: false
        }
    })
)