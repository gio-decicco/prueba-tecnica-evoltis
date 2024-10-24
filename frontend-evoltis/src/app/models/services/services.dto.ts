import { BaseResult } from "../base.result";
import { ServiceResponse } from "./service.response";

export interface ServicesDto extends BaseResult {
    services: ServiceResponse[]
}
