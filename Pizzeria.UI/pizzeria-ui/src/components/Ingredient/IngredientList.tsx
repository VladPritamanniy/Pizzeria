import { Ingredient } from "../../interfaces/Ingredient";
import IngredientItem from './IngredientItem';

interface Props{
    ingredients: Ingredient[],
    onChecked: (item :number) => void
}

export default function IngredientList({ingredients, onChecked}: Props){
    return(
        <>
            {ingredients.map(ingredient=>(
                <IngredientItem
                    key={ingredient.id}
                    onChecked={onChecked}
                    ingredient={ingredient}
                />
            ))}
        </>
    );
}