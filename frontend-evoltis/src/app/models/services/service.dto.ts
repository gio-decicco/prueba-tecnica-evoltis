import { BaseResult } from "../base.result";

export interface ServiceDto extends BaseResult{
    id: string;
    description: string;
    price: number;
    createdAt: Date;
    updatedAt: Date;
}
