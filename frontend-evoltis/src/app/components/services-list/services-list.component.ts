import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { MultiSelectModule } from 'primeng/multiselect';
import { PaginatorModule } from 'primeng/paginator';
import { PanelModule } from 'primeng/panel';
import { TableModule } from 'primeng/table';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../../models/services/service.response';
import { selectServices } from '../../store/selectors/services.selectors';
import { Store } from '@ngrx/store';
import { AppState } from '../../store/states/app.state';
import { getServices } from '../../store/actions/services.actions';

@Component({
  selector: 'app-services-list',
  standalone: true,
  imports: [CardModule, TableModule, PanelModule, ButtonModule, CommonModule, RouterModule, InputTextModule, CalendarModule, ReactiveFormsModule, PaginatorModule, MultiSelectModule],
  templateUrl: './services-list.component.html',
  styleUrl: './services-list.component.scss'
})
export class ServicesListComponent implements OnInit {

  formBuscar: FormGroup = new FormGroup({});

  services$: Observable<ServiceResponse[]> = new Observable<ServiceResponse[]>();

  constructor(private store: Store<AppState>, private fb: FormBuilder) {
    this.services$ = this.store.select(selectServices);

    this.formBuscar = this.fb.group({
      aprox: [null],
      dateCreatedFrom: [null],
      dateCreatedUntil: [null],
      priceMin: [null],
      priceMax: [null]
    })
  }

  ngOnInit(): void {
    this.store.dispatch(getServices({aprox: null, dateCreatedFrom: null, dateCreatedUntil: null, priceMin: null, priceMax: null}));
  }

  getServices() {
    const {aprox, dateCreatedFrom, dateCreatedUntil, priceMin, priceMax} = this.formBuscar.value;
    this.store.dispatch(getServices({aprox, dateCreatedFrom, dateCreatedUntil, priceMin, priceMax}));
  }
}
