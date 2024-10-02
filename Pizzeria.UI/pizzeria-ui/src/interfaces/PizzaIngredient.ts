import { Ingredient } from "./Ingredient";

export interface PizzaIngredient{
    id: number,
    pizzaId: number,
    ingredientId: number,
    ingredient: Ingredient
}