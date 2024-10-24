import { createAction, props } from "@ngrx/store";
import { ServiceDto } from "../../models/services/service.dto";
import { ServiceRequest } from "../../models/services/service.request";
import { ServiceResponse } from "../../models/services/service.response";

export const POST_SERVICE = 'POST_SERVICE';
export const POST_SERVICE_SUCCESS = 'POST_SERVICE_SUCCESS';
export const POST_SERVICE_ERROR = 'POST_SERVICE_ERROR';

export const MODIFY_SERVICE = 'MODIFY_SERVICE';
export const MODIFY_SERVICE_SUCCESS = 'MODIFY_SERVICE_SUCCESS';
export const MODIFY_SERVICE_ERROR = 'MODIFY_SERVICE_ERROR';

export const GET_SERVICE_BY_ID = 'GET_SERVICE_BY_ID';
export const GET_SERVICE_BY_ID_SUCCESS = 'GET_SERVICE_BY_ID_SUCCESS';
export const GET_SERVICE_BY_ID_ERROR = 'GET_SERVICE_BY_ID_ERROR';

export const GET_SERVICES = 'GET_SERVICES';
export const GET_SERVICES_SUCCESS = 'GET_SERVICES_SUCCESS';
export const GET_SERVICES_ERROR = 'GET_SERVICES_ERROR';

export const DELETE_SERVICE = 'DELETE_SERVICE';
export const DELETE_SERVICE_SUCCESS = 'DELETE_SERVICE_SUCCESS';
export const DELETE_SERVICE_ERROR = 'DELETE_SERVICE_ERROR'

export const postService = createAction(POST_SERVICE, props<{ service: ServiceRequest }>());
export const postServiceSuccess = createAction(POST_SERVICE_SUCCESS, props<{ service: ServiceDto }>());
export const postServiceError = createAction(POST_SERVICE_ERROR);

export const modifyService = createAction(MODIFY_SERVICE, props<{ id: string, service: ServiceRequest }>());
export const modifyServiceSuccess = createAction(MODIFY_SERVICE_SUCCESS, props<{ service: ServiceDto }>());
export const modifyServiceError = createAction(MODIFY_SERVICE_ERROR);

export const getServiceById = createAction(GET_SERVICE_BY_ID, props<{ id: string }>());
export const getServiceByIdSuccess = createAction(GET_SERVICE_BY_ID_SUCCESS, props<{ service: ServiceDto }>());
export const getServiceByIdError = createAction(GET_SERVICE_BY_ID_ERROR);

export const getServices = createAction(GET_SERVICES, 
    props<{ 
        aprox: string | null, 
        dateCreatedFrom: Date | null, 
        dateCreatedUntil: Date | null, 
        priceMin: number | null, 
        priceMax: number | null }>());
export const getServicesSuccess = createAction(GET_SERVICES_SUCCESS, props<{ services: ServiceResponse[] }>());
export const getServicesError = createAction(GET_SERVICES_ERROR);

export const deleteService = createAction(DELETE_SERVICE, props<{ id: string }>());
export const deleteServiceSuccess = createAction(DELETE_SERVICE_SUCCESS, props<{ service: ServiceDto }>());
export const deleteServiceError = createAction(DELETE_SERVICE_ERROR);