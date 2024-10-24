import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { ClientRequest } from '../../models/clients/client.request';
import { ServiceResponse } from '../../models/services/service.response';
import { getClientById, modifyClient, postClient } from '../../store/actions/clients.actions';
import { getServices } from '../../store/actions/services.actions';
import { selectClient, selectClientsAdded, selectClientsLoading, selectClientsModified } from '../../store/selectors/clients.selectors';
import { selectServices, selectServicesLoading } from '../../store/selectors/services.selectors';
import { AppState } from '../../store/states/app.state';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { MultiSelectModule } from 'primeng/multiselect';
import { PanelModule } from 'primeng/panel';
import { ActivatedRoute } from '@angular/router';
import { ClientDto } from '../../models/clients/client.dto';

@Component({
  selector: 'app-modify-client',
  standalone: true,
  imports: [PanelModule, ReactiveFormsModule, InputTextModule, ButtonModule, CommonModule, MultiSelectModule],
  templateUrl: './modify-client.component.html',
  styleUrl: './modify-client.component.scss'
})
export class ModifyClientComponent implements OnInit{
  form: FormGroup = new FormGroup({});
  services$ : Observable<ServiceResponse[]> = new Observable<ServiceResponse[]>();
  client$ : Observable<ClientDto | null> = new Observable<ClientDto>();
  id = "";

  constructor(private store: Store<AppState>, private fb: FormBuilder, private activatedRoute : ActivatedRoute) {
    this.form = this.fb.group({
      name: [null, [Validators.required, Validators.minLength(2)]],
      surname: [null, [Validators.required, Validators.minLength(2)]],
      email: [null, [Validators.required, Validators.email]],
      services: [null]
    })

    this.services$ = this.store.select(selectServices);
    this.client$ = this.store.select(selectClient);
  }
  ngOnInit(): void {
    this.store.dispatch(getServices({aprox: null, dateCreatedFrom: null, dateCreatedUntil: null, priceMin: null, priceMax: null}));
    
    const sub = this.activatedRoute.params.subscribe(params => {
        const id = params['id'];
        this.id = id;
        if(id){
            this.store.dispatch(getClientById({id}));
            const sub2 = this.store.select(selectClientsLoading).subscribe(loading => {
                if(!loading){
                    const sub3 = this.client$.subscribe(client => {
                        if(client){
                            this.form.patchValue({
                                name: client.name,
                                surname: client.surname,
                                email: client.email,
                                services: client.services.map(service => service.id)
                            });
                            sub3.unsubscribe();
                        }
                    });
                    sub2.unsubscribe();
                }
            });
            sub.unsubscribe();
        }
    });
}

  createClient(){
    if(this.form.valid){
      console.log(this.form.value);

      const request = this.form.value as ClientRequest;
      console.log(request);

      this.store.dispatch(modifyClient({id: this.id, client: request}));

      const sub = this.store.select(selectClientsModified).subscribe(added => {
        if(added){
          sub.unsubscribe();
          this.form.reset();
        }
      })
    }
  }
}
