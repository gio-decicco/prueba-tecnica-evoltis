import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { ServicesService } from "../../services/services.service";
import { switchMap, map, catchError, of } from "rxjs";
import { getServices, getServicesSuccess, getServicesError, getServiceById, getServiceByIdSuccess, getServiceByIdError, modifyService, modifyServiceSuccess, modifyServiceError, deleteService, deleteServiceSuccess, deleteServiceError, postService, postServiceSuccess, postServiceError } from "../actions/services.actions";
import { MessageService } from "primeng/api";

@Injectable({ providedIn: 'root' })
export class ServicesEffects { 

    constructor(private service: ServicesService, private actions$: Actions, private messageService: MessageService) {}

    getServices$ = createEffect(() => this.actions$.pipe(
        ofType(getServices),
        switchMap((action) => this.service.getServices(action.aprox, action.dateCreatedFrom, action.dateCreatedUntil, action.priceMin, action.priceMax).pipe(
            map((services) => { 
                if(services.ok){
                    // this.messageService.add({severity: 'success', summary: 'Success', detail: 'Services loaded'}); 
                    return getServicesSuccess({services: services.services})
                }
                else{
                    return getServicesError()
                }
            }),
            catchError(() => of(getServicesError()))
        ))
    ))

    getServiceById$ = createEffect(() => this.actions$.pipe(
        ofType(getServiceById),
        switchMap((action) => this.service.getServiceById(action.id).pipe(
            map((service) => getServiceByIdSuccess({service})),
            catchError(() => of(getServiceByIdError()))
        ))
    ))

    modifyService$ = createEffect(() => this.actions$.pipe(
        ofType(modifyService),
        switchMap((action) => this.service.modifyService(action.id, action.service).pipe(
            map((service) => modifyServiceSuccess({service})),
            catchError(() => of(modifyServiceError()))
        ))
    ))

    deleteService$ = createEffect(() => this.actions$.pipe(
        ofType(deleteService),
        switchMap((action) => this.service.deleteService(action.id).pipe(
            map((service) => { 
                if(service.ok){
                    this.messageService.add({severity: 'success', summary: 'Success', detail: 'Service deleted'}); 
                    return deleteServiceSuccess({service})
                }
                else{
                    return deleteServiceError()
                }
            }),
            catchError(() => of(deleteServiceError()))
        ))
    ))

    postService$ = createEffect(() => this.actions$.pipe(
        ofType(postService),
        switchMap((action) => this.service.postService(action.service).pipe(
            map((service) => postServiceSuccess({service})),
            catchError(() => of(postServiceError()))
        ))
    ))
}