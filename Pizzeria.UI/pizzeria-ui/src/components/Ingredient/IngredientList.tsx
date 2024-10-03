import { Ingredient } from "../../interfaces/Ingredient";
import IngredientItem from './IngredientItem';

interface Props{
    ingredients: Ingredient[],
    selectedIngredients: number[],
    onChecked: (item :number) => void
}

export default function IngredientList({ingredients, onChecked, selectedIngredients}: Props){
    return(
        <>
            {ingredients.map(ingredient=>(
                <IngredientItem
                    key={ingredient.id}
                    onChecked={onChecked}
                    ingredient={ingredient}
                />
            ))}
            <input type="hidden" value={selectedIngredients.join(',')}/>
        </>
    );
}