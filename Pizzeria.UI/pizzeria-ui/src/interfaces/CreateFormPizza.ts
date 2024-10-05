import { SizesWithStringPrice } from "./SizesWithStringPrice";

export interface CreateFormPizza{
    name: string,
    pizzaImg: File,
    sizesWithPrice: SizesWithStringPrice[]
    ingredientIds: number[]
}