import axios from "axios";
import { BASE_API_URL } from "../constants/BASE_API_URL";
import { PizzaDisplayOrdering } from "../interfaces/PizzaDisplayOrdering";

export async function getPizzaForChangingDisplayOrder(): Promise<PizzaDisplayOrdering[]> {
    const { data } = await axios.get(BASE_API_URL + '/api/Pizza');
    return data;
}

export async function changePizzaDisplayOrdering(data: PizzaDisplayOrdering[]) {
    await axios.post(`${BASE_API_URL}/api/Pizza`, data);
}