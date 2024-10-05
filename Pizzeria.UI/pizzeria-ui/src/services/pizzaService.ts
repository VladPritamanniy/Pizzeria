import axios from "axios";
import { BASE_API_URL } from "../constants/BASE_API_URL";
import { PizzaDisplayOrdering } from "../interfaces/PizzaDisplayOrdering";
import { SizeWithPrice } from "../interfaces/SizeWithPrice";
import { CreateFormPizza } from "../interfaces/CreateFormPizza";

export async function getPizzaForChangingDisplayOrder(): Promise<PizzaDisplayOrdering[]> {
    const { data } = await axios.get(BASE_API_URL + '/api/Pizza/GetPizzaForChangingDisplayOrder');
    return data;
}

export async function createPizza(request: Request): Promise<void> {
    const formData = await request.formData();

    const selectedIngredientIdsData = formData.get('selectedIngredientIds') as string;
    const selectedIngredientIds = selectedIngredientIdsData ? selectedIngredientIdsData.split(',').map(Number) : [];

    const sizeData = formData.get('sizesWithPrice') as string;
    const sizesWithPrice: SizeWithPrice[] = sizeData ? JSON.parse(sizeData) : [];
    const formatedSizesWithPrice = sizesWithPrice.map(
        (item: SizeWithPrice) => {
            return { ...item, price: new Intl.NumberFormat().format(item.price) }
            }
        );
        
    const updates: CreateFormPizza = {
        name: formData.get('name') as string,
        pizzaImg: formData.get('pizzaImg') as File,
        sizesWithPrice: formatedSizesWithPrice,
        ingredientIds: selectedIngredientIds
    };

    await axios.post(`${BASE_API_URL}/api/Pizza/CreatePizza`, updates, {
        headers: {
            'Content-Type': 'multipart/form-data',
        },
    });
}

export async function changePizzaDisplayOrdering(data: PizzaDisplayOrdering[]) {
    await axios.post(`${BASE_API_URL}/api/Pizza/ChangePizzaDisplayOrdering`, data);
}