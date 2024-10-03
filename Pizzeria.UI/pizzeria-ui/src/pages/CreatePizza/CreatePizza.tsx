import styles from './CreatePizza.module.scss';
import { useEffect, useState } from "react";
import {
    Form,
    redirect,
    ActionFunction,
} from "react-router-dom";
import { Ingredient } from "../../interfaces/Ingredient";
import { SizeWithPrice } from "../../interfaces/SizeWithPrice";
import { getAllSizes } from "../../services/sizeService";
import { getAllIngredients } from "../../services/ingredientService";
import { createPizza } from "../../services/menuService";
import IngredientList from "../../components/Ingredient/IngredientList";
import SizeList from '../../components/Size/SizeList';

export const action: ActionFunction = async ({ request }) => {
    await createPizza(request);
    return redirect(`/`);
};

export default function CreatePizza() {
    const [sizesWithPrice, setSizeWithPrice] = useState<SizeWithPrice[]>([]);
    const [ingredients, setIngredients] = useState<Ingredient[]>([]);
    const [selectedIngredientIds, setSelectedIngredientId] = useState<number[]>([]);
    
    const handleSizeChange = (index: number, updatedSize: SizeWithPrice) => {
        const updatedSizes = [...sizesWithPrice];
        updatedSizes[index] = updatedSize;
        setSizeWithPrice(updatedSizes);
    };

    useEffect(() => {
        const fenchData = async () => {
            const response = await getAllSizes();
            setSizeWithPrice(response);
        }

        fenchData();
    }, []);
    
    useEffect(() => {
        const fenchData = async () => {
            const response = await getAllIngredients();
            setIngredients(response);
        }
        
        fenchData();
    }, []);

    function checkHandler(i: number){
        if(selectedIngredientIds.includes(i)){
            setSelectedIngredientId(selectedIngredientIds.filter( item => item !== i ));
        }
        else{
            setSelectedIngredientId([...selectedIngredientIds, i]);
        }
    }

    return (
        <>
            <Form className={styles.form} method="post" encType="multipart/form-data">
                <label>
                    <span>Name</span>
                    <input
                        placeholder="Name"
                        aria-label="Name"
                        type="text"
                        name="name"
                    />
                </label>
                <label className={styles.imageLabel}>
                    <span>Image</span>
                    <input
                        placeholder="PizzaImg"
                        aria-label="PizzaImg"
                        type="file"
                        name="pizzaImg"
                        multiple={false}
                    />
                </label>
                <div className={styles.ingredients}>
                    <IngredientList
                        ingredients={ingredients}
                        selectedIngredients={selectedIngredientIds}
                        onChecked={checkHandler}
                    />
                    <input type='hidden' name="selectedIngredientIds" value={selectedIngredientIds.join(',')}/>
                </div>
                <div className={styles.sizesContainer}>
                    <label className={styles.priceLabel}>Price</label>
                    <SizeList
                        sizeList={sizesWithPrice}
                        onChangeHandler={handleSizeChange}
                    />
                    <input type='hidden' name="sizesWithPrice" value={JSON.stringify(sizesWithPrice)}/>
                </div>
                <button type="submit">Save</button>
            </Form>
        </>
    );
}