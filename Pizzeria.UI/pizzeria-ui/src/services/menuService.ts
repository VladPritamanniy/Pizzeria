import axios from "axios";
import { CreateFormPizza } from "../interfaces/CreateFormPizza";
import { Pizza } from "../interfaces/Pizza";

const BASE_URL = 'https://localhost:7147';

export async function getAllPizzas(): Promise<Pizza[]> {
    const { data } = await axios.get(BASE_URL + '/api/Menu');
    return data.pizzas;
}

export async function createPizza(data: CreateFormPizza): Promise<void> {
    const formData = new FormData();
    formData.append('name', data.name);
    formData.append('pizzaImg', data.pizzaImg);
    await axios.post(`${BASE_URL}/api/Menu`, formData, {
        headers: {
            'Content-Type': 'multipart/form-data',
        },
    });
}