import { SizeWithPrice } from "./SizeWithPrice";

export interface CreateFormPizza{
    name: string,
    pizzaImg: File,
    sizesWithPrice: SizeWithPrice[]
    ingredientIds: number[]
}