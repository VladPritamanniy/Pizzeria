import { PizzaIngredient } from "./PizzaIngredient"
import { PizzaPrice } from "./PizzaPrice"

export interface Pizza{
    id: number,
    name: string,
    publicImageId: string,
    displayOrder: number,
    pizzaIngredients: PizzaIngredient[],
    pizzaPrices: PizzaPrice[]
}