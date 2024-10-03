import axios from "axios";
import { CreateFormPizza } from "../interfaces/CreateFormPizza";
import { Pizza } from "../interfaces/Pizza";
import { BASE_API_URL } from '../constants/BASE_API_URL.ts';
import { SizeWithPrice } from "../interfaces/SizeWithPrice";

export async function getAllPizzas(): Promise<Pizza[]> {
    const { data } = await axios.get(BASE_API_URL + '/api/Menu');
    return data.pizzas;
}

export async function createPizza(request: Request): Promise<void> {
    const formData = await request.formData();
    
    const selectedIngredientIdsData = formData.get('selectedIngredientIds') as string;
    const selectedIngredientIds = selectedIngredientIdsData ? selectedIngredientIdsData.split(',').map(Number) : [];

    const sizeData = formData.get('sizesWithPrice') as string;
    const sizesWithPrice: SizeWithPrice[] = sizeData ? JSON.parse(sizeData) : [];

    const updates: CreateFormPizza = {
        name: formData.get('name') as string,
        pizzaImg: formData.get('pizzaImg') as File,
        sizesWithPrice: sizesWithPrice,
        ingredientIds: selectedIngredientIds
    };
    
    await axios.post(`${BASE_API_URL}/api/Menu`, updates, {
        headers: {
            'Content-Type': 'multipart/form-data',
        },
    });
}