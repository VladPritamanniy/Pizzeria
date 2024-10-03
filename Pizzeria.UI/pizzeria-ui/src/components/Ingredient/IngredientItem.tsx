import styles from './IngredientItem.module.scss';
import { Ingredient } from "../../interfaces/Ingredient";

interface Props {
    ingredient: Ingredient;
    onChecked: (item: number) => void;
}

export default function IngredientItem({ ingredient, onChecked }: Props) {
    return (
        <label className={styles.ingredientItem}>
            <input
                type="checkbox"
                className={styles.switchInput}
                onChange={() => onChecked(ingredient.id)}
            />
            <span className={styles.switchSlider}></span>
            <span className={styles.ingredientName}>{ingredient.name}</span>
            <span className={styles.ingredientCost}>{ingredient.baseCost}</span>
        </label>
    );
}