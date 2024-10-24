import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceDto } from '../models/services/service.dto';
import { formatISO } from 'date-fns';
import { environment } from '../../environments/environment.development';
import { ServiceRequest } from '../models/services/service.request';
import { ServicesDto } from '../models/services/services.dto';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private http: HttpClient) { }

  getServices(
    aprox: string | null, 
    dateCreatedFrom: Date | null, 
    dateCreatedUntil: Date | null, 
    priceMin: number | null, 
    priceMax: number | null): Observable<ServicesDto>{

    let params = new URLSearchParams();
    if(aprox) params.set('Aprox', aprox);
    if(dateCreatedFrom) params.set('DateCreatedFrom', formatISO(dateCreatedFrom, { representation: 'complete' }));
    if(dateCreatedUntil) params.set('DateCreatedTo', formatISO(dateCreatedUntil, { representation: 'complete' }));
    if(priceMin) params.set('PriceMin', priceMin.toString());
    if(priceMax) params.set('PriceMax', priceMax.toString());

    return this.http.get<ServicesDto>(environment.apiUrl + `services?` + params.toString());
  }

  getServiceById(id: string): Observable<ServiceDto> {
    return this.http.get<ServiceDto>(environment.apiUrl + `services/${id}`);
  }

  postService(service: ServiceRequest): Observable<ServiceDto> {
    return this.http.post<ServiceDto>(environment.apiUrl + 'services', service);
  }

  modifyService(id: string, service: ServiceRequest): Observable<ServiceDto> {
    return this.http.put<ServiceDto>(environment.apiUrl + `services/${id}`, service);
  }

  deleteService(id: string): Observable<ServiceDto> {
    return this.http.delete<ServiceDto>(environment.apiUrl + `services/${id}`);
  }
}
