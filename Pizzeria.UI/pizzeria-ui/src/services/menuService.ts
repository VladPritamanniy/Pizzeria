import axios from "axios";
import { Pizza } from "../interfaces/Pizza";
import { BASE_API_URL } from '../constants/BASE_API_URL.ts';

export async function getAllPizzas(): Promise<Pizza[]> {
    const { data } = await axios.get(BASE_API_URL + '/api/Menu/GetAllPizzas');
    return data.pizzas;
}