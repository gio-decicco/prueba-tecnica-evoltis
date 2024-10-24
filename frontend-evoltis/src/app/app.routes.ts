import { Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { ClientsComponent } from './components/clients/clients.component';
import { NewClientComponent } from './components/new-client/new-client.component';
import { ModifyClientComponent } from './components/modify-client/modify-client.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { ServicesListComponent } from './components/services-list/services-list.component';

export const routes: Routes = [
    {
        path: 'clients',
        children:[
            {
                path: '',
                component: ClientsComponent
            },
            {
                path: 'new',
                component: NewClientComponent
            },
            {
                path: ':id',
                component: ModifyClientComponent
            }
        ]
    },
    {
        path: 'services',
        component: ServicesListComponent
    },
    {
        path: 'contact',
        component: ContactsComponent
    },
    {
        path: '**',
        redirectTo: 'clients'
    }
];
