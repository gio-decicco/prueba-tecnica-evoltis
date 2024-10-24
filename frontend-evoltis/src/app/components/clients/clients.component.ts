import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { PanelModule } from 'primeng/panel';
import { TableModule } from 'primeng/table';
import { AppState } from '../../store/states/app.state';
import { Observable } from 'rxjs';
import { ClientResponse } from '../../models/clients/client.response';
import { selectClients } from '../../store/selectors/clients.selectors';
import { deleteClient, getClients } from '../../store/actions/clients.actions';
import { RouterModule } from '@angular/router';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { PaginatorModule } from 'primeng/paginator';
import { ServiceResponse } from '../../models/services/service.response';
import { MultiSelectModule } from 'primeng/multiselect';
import { getServices } from '../../store/actions/services.actions';
import { selectServices } from '../../store/selectors/services.selectors';

@Component({
  selector: 'app-clients',
  standalone: true,
  imports: [CardModule, TableModule, PanelModule, ButtonModule, CommonModule, RouterModule, InputTextModule, CalendarModule, ReactiveFormsModule, PaginatorModule, MultiSelectModule],
  templateUrl: './clients.component.html',
  styleUrl: './clients.component.scss'
})
export class ClientsComponent implements OnInit{
  clients$: Observable<ClientResponse[]> = new Observable<ClientResponse[]>();
  formBuscar: FormGroup = new FormGroup({});
  services$ : Observable<ServiceResponse[]> = new Observable<ServiceResponse[]>();

  constructor(private store: Store<AppState>, private fb: FormBuilder){
    this.clients$ = this.store.select(selectClients);
    this.services$ = this.store.select(selectServices);
    this.formBuscar = this.fb.group({
      aprox: [null],
      dateCreatedFrom: [null],
      dateCreatedUntil: [null],
      services: [null]
    })
  }

  ngOnInit(): void {
    this.store.dispatch(getClients({aprox: null, dateCreatedFrom: null, dateCreatedUntil: null, services: []}));
    this.store.dispatch(getServices({aprox: null, dateCreatedFrom: null, dateCreatedUntil: null, priceMin: null, priceMax: null}));
  }

  deleteClient(id: string){
    this.store.dispatch(deleteClient({id}));
  }

  getClients(){
    const {aprox, dateCreatedFrom, dateCreatedUntil, services} = this.formBuscar.value;

    console.log(aprox, dateCreatedFrom, dateCreatedUntil, services);

    this.store.dispatch(getClients({aprox, dateCreatedFrom, dateCreatedUntil, services}));
  }

  getTotalCharges(services: ServiceResponse[]): number {
    return services.reduce((sum, service) => sum + service.price, 0);
  }
}
