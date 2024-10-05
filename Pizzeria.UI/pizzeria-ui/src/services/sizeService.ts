import axios from "axios";
import { BASE_API_URL } from "../constants/BASE_API_URL";
import { SizeWithPrice } from "../interfaces/SizeWithPrice";

export async function getAllSizes(): Promise<SizeWithPrice[]> {
    const { data } = await axios.get(BASE_API_URL + '/api/Size/GetAllSizes');
    return data;
}