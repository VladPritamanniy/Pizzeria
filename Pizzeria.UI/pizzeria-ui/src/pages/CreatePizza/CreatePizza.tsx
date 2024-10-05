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
import { createPizza } from "../../services/pizzaService";
import IngredientList from "../../components/Ingredient/IngredientList";
import SizeList from '../../components/Size/SizeList';

export const action: ActionFunction = async ({ request }) => {
    await createPizza(request);
    return redirect(`/`);
};

export default function CreatePizza() {
    const [pizzaName, setPizzaName] = useState('');
    const [pizzaImg, setPizzaImg] = useState<File | null>(null);
    const [ingredients, setIngredients] = useState<Ingredient[]>([]);
    const [sizesWithPrice, setSizeWithPrice] = useState<SizeWithPrice[]>([]);
    const [selectedIngredientIds, setSelectedIngredientId] = useState<number[]>([]);
    const [isLoading, setLoading] = useState({ sizesWithPrice: true, ingredients: true });
    const [isFormValid, setIsFormValid] = useState(false);

    const handleSizeChange = (index: number, updatedSize: SizeWithPrice) => {
        const updatedSizes = [...sizesWithPrice];
        updatedSizes[index] = updatedSize;
        setSizeWithPrice(updatedSizes);
    };

    useEffect(() => {
        const fenchData = async () => {
            const response = await getAllSizes();
            setSizeWithPrice(response);
            setLoading(prevState => ({ ...prevState, sizesWithPrice: false }));
        }

        fenchData();
    }, []);

    useEffect(() => {
        const fenchData = async () => {
            const response = await getAllIngredients();
            setIngredients(response);
            setLoading(prevState => ({ ...prevState, ingredients: false }));
        }

        fenchData();
    }, []);

    useEffect(() => {
        const isValid =
            pizzaName.trim() !== '' &&
            pizzaImg !== null &&
            selectedIngredientIds.length > 0 &&
            sizesWithPrice.every(size => size.price > 0);

        setIsFormValid(isValid);
    }, [pizzaName, pizzaImg, selectedIngredientIds, sizesWithPrice]);

    function checkHandler(i: number) {
        if (selectedIngredientIds.includes(i)) {
            setSelectedIngredientId(selectedIngredientIds.filter(item => item !== i));
        }
        else {
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
                        value={pizzaName}
                        onChange={(e) => setPizzaName(e.target.value)}
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
                        onChange={(e) => setPizzaImg(e.target.files?.[0] || null)}
                    />
                </label>
                <div className={styles.ingredients}>
                    <label className={styles.ingredientLabel}>Ingredients</label>
                    {isLoading.ingredients
                        ? (<span className={styles.loader}></span>)
                        : (
                            <IngredientList
                                ingredients={ingredients}
                                onChecked={checkHandler}
                            />
                        )}
                    <input type='hidden' name="selectedIngredientIds" value={selectedIngredientIds.join(',')} />
                </div>
                <div className={styles.sizesContainer}>
                    <label className={styles.priceLabel}>Price</label>
                    {isLoading.sizesWithPrice
                        ? (<span className={styles.loader}></span>)
                        : (
                            <SizeList
                                sizeList={sizesWithPrice}
                                onChangeHandler={handleSizeChange}
                            />
                        )}

                    <input type='hidden' name="sizesWithPrice" value={JSON.stringify(sizesWithPrice)} />
                </div>
                <button type="submit" className={styles.submitBtn} disabled={!isFormValid}>Save</button>
            </Form>
        </>
    );
}