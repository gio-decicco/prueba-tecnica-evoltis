import { ServiceResponse } from "../services/service.response";

export interface ClientResponse {
    id: string;
    name: string;
    surname: string;
    email: string;
    services: ServiceResponse[];
}
