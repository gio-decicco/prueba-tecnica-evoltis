import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { provideHttpClient } from '@angular/common/http';
import { ROOT_REDUCERS } from './store/states/app.state';
import { ClientsEffects } from './store/effects/clients.effects';
import { MessageService } from 'primeng/api';
import { ServicesEffects } from './store/effects/services.effects';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideAnimations(),
    provideHttpClient(),
    provideStore(ROOT_REDUCERS),
    provideEffects([ClientsEffects, ServicesEffects]),
    provideStoreDevtools({ maxAge: 25, logOnly: !isDevMode() }),
    MessageService
]
};
