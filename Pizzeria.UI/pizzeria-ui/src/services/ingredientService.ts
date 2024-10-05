import axios from "axios";
import { Ingredient } from "../interfaces/Ingredient";
import { BASE_API_URL } from "../constants/BASE_API_URL";

export async function getAllIngredients(): Promise<Ingredient[]> {
    const { data } = await axios.get(BASE_API_URL + '/api/Ingredient/GetAllIngredients');
    return data;
}

export async function createIngredient(data: Ingredient): Promise<void> {
    await axios.post(`${BASE_API_URL}/api/Ingredient/CreateIngredient`, data);
}