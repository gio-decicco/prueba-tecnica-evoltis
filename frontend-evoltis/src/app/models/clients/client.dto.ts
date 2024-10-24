import { BaseResult } from "../base.result";
import { ServiceResponse } from "../services/service.response";

export interface ClientDto extends BaseResult {
    id: string;
    name: string;
    surname: string;
    email: string;
    services: ServiceResponse[];
}
