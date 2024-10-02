import { PizzaPrice } from "./PizzaPrice";

export interface CreateFormPizza{
    name: string,
    pizzaImg: File,
    pizzaPrices: PizzaPrice[]
}