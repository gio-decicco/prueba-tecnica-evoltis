import { createAction, props } from "@ngrx/store";
import { ClientRequest } from "../../models/clients/client.request";
import { ClientDto } from "../../models/clients/client.dto";
import { ClientResponse } from "../../models/clients/client.response";

export const POST_CLIENT = 'POST_CLIENT';
export const POST_CLIENT_SUCCESS = 'POST_CLIENT_SUCCESS';
export const POST_CLIENT_ERROR = 'POST_CLIENT_ERROR';

export const MODIFY_CLIENT = 'MODIFY_CLIENT';
export const MODIFY_CLIENT_SUCCESS = 'MODIFY_CLIENT_SUCCESS';
export const MODIFY_CLIENT_ERROR = 'MODIFY_CLIENT_ERROR';

export const GET_CLIENT_BY_ID = 'GET_CLIENT_BY_ID';
export const GET_CLIENT_BY_ID_SUCCESS = 'GET_CLIENT_BY_ID_SUCCESS';
export const GET_CLIENT_BY_ID_ERROR = 'GET_CLIENT_BY_ID_ERROR';

export const GET_CLIENTS = 'GET_CLIENTS';
export const GET_CLIENTS_SUCCESS = 'GET_CLIENTS_SUCCESS';
export const GET_CLIENTS_ERROR = 'GET_CLIENTS_ERROR';

export const DELETE_CLIENT = 'DELETE_CLIENT';
export const DELETE_CLIENT_SUCCESS = 'DELETE_CLIENT_SUCCESS'
export const DELETE_CLIENT_ERROR = 'DELETE_CLIENT_ERROR'

export const postClient = createAction(POST_CLIENT, props<{ client: ClientRequest }>());
export const postClientSuccess = createAction(POST_CLIENT_SUCCESS, props<{ client: ClientDto }>());
export const postClientError = createAction(POST_CLIENT_ERROR);

export const modifyClient = createAction(MODIFY_CLIENT, props<{ id: string, client: ClientRequest }>());
export const modifyClientSuccess = createAction(MODIFY_CLIENT_SUCCESS, props<{ client: ClientDto }>());
export const modifyClientError = createAction(MODIFY_CLIENT_ERROR);

export const getClientById = createAction(GET_CLIENT_BY_ID, props<{ id: string }>());
export const getClientByIdSuccess = createAction(GET_CLIENT_BY_ID_SUCCESS, props<{ client: ClientDto }>());
export const getClientByIdError = createAction(GET_CLIENT_BY_ID_ERROR);

export const getClients = createAction(GET_CLIENTS, props<{ aprox: string | null, dateCreatedFrom: Date | null, dateCreatedUntil: Date | null, services: string[] }>());
export const getClientsSuccess = createAction(GET_CLIENTS_SUCCESS, props<{ clients: ClientResponse[] }>());
export const getClientsError = createAction(GET_CLIENTS_ERROR);

export const deleteClient = createAction(DELETE_CLIENT, props<{ id: string }>());
export const deleteClientSuccess = createAction(DELETE_CLIENT_SUCCESS, props<{ client: ClientDto }>());
export const deleteClientError = createAction(DELETE_CLIENT_ERROR);