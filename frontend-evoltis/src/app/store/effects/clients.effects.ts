import { Injectable } from "@angular/core";
import { ClientsService } from "../../services/clients.service";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { switchMap, map, catchError, of } from "rxjs";
import { getClientsSuccess, getClientsError, getClients, getClientById, getClientByIdError, getClientByIdSuccess, modifyClient, modifyClientError, modifyClientSuccess, deleteClient, deleteClientError, deleteClientSuccess, postClient, postClientError, postClientSuccess } from "../actions/clients.actions";
import { MessageService } from "primeng/api";

@Injectable({providedIn: 'root'})
export class ClientsEffects{

    constructor(private service: ClientsService, private actions$: Actions, private messageService: MessageService){}

    getClients$ = createEffect(() => this.actions$.pipe(
        ofType(getClients),
        switchMap((action) => this.service.getClients(action.aprox, action.dateCreatedFrom, action.dateCreatedUntil, action.services).pipe(
            map((clients) => { 
                if(clients.ok){
                    // this.messageService.add({severity: 'success', summary: 'Success', detail: 'Clients loaded'});
                    return getClientsSuccess({clients: clients.clients})
                }
                else{
                    return getClientsError()
                }
            }),
            catchError(() => of(getClientsError()))
        ))
    ))

    getClientById$ = createEffect(() => this.actions$.pipe(
        ofType(getClientById),
        switchMap((action) => this.service.getClientById(action.id).pipe(
            map((client) => getClientByIdSuccess({client: client})),
            catchError(() => of(getClientByIdError()))
        ))
    ))

    modifyClient$ = createEffect(() => this.actions$.pipe(
        ofType(modifyClient),
        switchMap((action) => this.service.modifyClient(action.id, action.client).pipe(
            map((client) => {
                this.messageService.add({severity: 'success', summary: 'Success', detail: 'Client modified'});
                return modifyClientSuccess({client: client})
            }),
            catchError(() => of(modifyClientError()))
        ))
    ))

    deleteClient$ = createEffect(() => this.actions$.pipe(
        ofType(deleteClient),
        switchMap((action) => this.service.deleteClient(action.id).pipe(
            map((client) => {
                this.messageService.add({severity: 'warning', summary: 'Warning', detail: 'Client deleted'});
                return deleteClientSuccess({client: client})
            }),
            catchError(() => of(deleteClientError()))
        ))
    ))

    postClient$ = createEffect(() => this.actions$.pipe(
        ofType(postClient),
        switchMap((action) => this.service.postClient(action.client).pipe(
            map((client) => {
                this.messageService.add({severity: 'success', summary: 'Success', detail: 'Client created'});
                return postClientSuccess({client: client})
            }),
            catchError(() => of(postClientError()))
        ))
    ))
}