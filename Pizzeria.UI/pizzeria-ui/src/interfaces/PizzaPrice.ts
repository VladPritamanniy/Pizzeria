import { Price } from "./Price";
import { Size } from "./Size";

export interface PizzaPrice{
    id: number,
    pizzaId: number,
    sizeId: number,
    priceId: number,
    size: Size,
    price: Price 
}