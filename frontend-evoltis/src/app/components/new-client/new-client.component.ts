import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { PanelModule } from 'primeng/panel';
import { AppState } from '../../store/states/app.state';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../models/services/service.response';
import { CommonModule } from '@angular/common';
import { MultiSelectModule } from 'primeng/multiselect';
import { getServices } from '../../store/actions/services.actions';
import { selectServices } from '../../store/selectors/services.selectors';
import { ClientRequest } from '../../models/clients/client.request';
import { postClient } from '../../store/actions/clients.actions';
import { selectClientsAdded } from '../../store/selectors/clients.selectors';

@Component({
  selector: 'app-new-client',
  standalone: true,
  imports: [PanelModule, ReactiveFormsModule, InputTextModule, ButtonModule, CommonModule, MultiSelectModule],
  templateUrl: './new-client.component.html',
  styleUrl: './new-client.component.scss'
})
export class NewClientComponent implements OnInit{
  form: FormGroup = new FormGroup({});
  services$ : Observable<ServiceResponse[]> = new Observable<ServiceResponse[]>();

  constructor(private store: Store<AppState>, private fb: FormBuilder){
    this.form = this.fb.group({
      name: [null, [Validators.required, Validators.minLength(2)]],
      surname: [null, [Validators.required, Validators.minLength(2)]],
      email: [null, [Validators.required, Validators.email]],
      services: [null]
    })

    this.services$ = this.store.select(selectServices);
  }
  ngOnInit(): void {
    this.store.dispatch(getServices({aprox: null, dateCreatedFrom: null, dateCreatedUntil: null, priceMin: null, priceMax: null}));
  }

  createClient(){
    if(this.form.valid){
      console.log(this.form.value);

      const request = this.form.value as ClientRequest;
      console.log(request);

      this.store.dispatch(postClient({client: request}));

      const sub = this.store.select(selectClientsAdded).subscribe(added => {
        if(added){
          sub.unsubscribe();
          this.form.reset();
        }
      })
    }
  }
}
