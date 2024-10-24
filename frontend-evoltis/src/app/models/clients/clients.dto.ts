import { BaseResult } from "../base.result";
import { ClientResponse } from "./client.response";

export interface ClientsDto extends BaseResult{
    clients: ClientResponse[];
}
