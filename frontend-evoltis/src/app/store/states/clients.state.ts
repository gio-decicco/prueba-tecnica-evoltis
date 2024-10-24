import { ClientDto } from "../../models/clients/client.dto";
import { ClientResponse } from "../../models/clients/client.response";

export interface ClientState {
    client: ClientDto | null;
    clients: ClientResponse[];
    loading: boolean;
    added: boolean;
    modified: boolean;
    deleted: boolean;
}