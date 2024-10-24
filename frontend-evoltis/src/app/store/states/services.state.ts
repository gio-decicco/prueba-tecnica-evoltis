import { ServiceDto } from "../../models/services/service.dto";
import { ServiceResponse } from "../../models/services/service.response";

export interface ServicesState{
    services: ServiceResponse[],
    service: ServiceDto | null,
    loading: boolean,
    added: boolean,
    modified: boolean,
    deleted: boolean
}