import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { ClientRequest } from '../models/clients/client.request';
import { Observable } from 'rxjs';
import { ClientDto } from '../models/clients/client.dto';
import { format, formatISO } from 'date-fns';
import { ClientsDto } from '../models/clients/clients.dto';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  constructor(private http: HttpClient) { }

  postClient(client: ClientRequest): Observable<ClientDto> {
    return this.http.post<ClientDto>(environment.apiUrl + 'clients', client);
  }
  modifyClient(id: string, client: ClientRequest): Observable<ClientDto> {
    return this.http.put<ClientDto>(environment.apiUrl + `clients/${id}`, client);
  }
  getClientById(id: string): Observable<ClientDto> {
    return this.http.get<ClientDto>(environment.apiUrl + `clients/${id}`);
  }

  getClients(aprox: string | null, dateCreatedFrom: Date | null, dateCreatedUntil: Date | null, services: string[] | null): Observable<ClientsDto> {
    let params = new URLSearchParams();
    if(aprox) params.set('Aprox', aprox);
    if(dateCreatedFrom) params.set('DateCreatedFrom', formatISO(dateCreatedFrom, { representation: 'complete' }));
    if(dateCreatedUntil) params.set('DateCreatedUntil', formatISO(dateCreatedUntil, { representation: 'complete' }));
    services?.forEach(service => {
      params.append('Services', service);
  });

    return this.http.get<ClientsDto>(environment.apiUrl + `clients?` + params.toString());
  }

  deleteClient(id: string): Observable<ClientDto> {
    return this.http.delete<ClientDto>(environment.apiUrl + `clients/${id}`);
  }
}
