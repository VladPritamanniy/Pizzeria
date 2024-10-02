import {
    Form,
    redirect,
    ActionFunction,
} from "react-router-dom";
import { createPizza } from "../../services/menuService";
import styles from './CreatePizza.module.scss';
import { CreateFormPizza } from "../../interfaces/CreateFormPizza";

export const action: ActionFunction = async ({ request }) => {
    const formData = await request.formData();
    const updates: CreateFormPizza = {
        name: formData.get('name') as string,
        pizzaImg: formData.get('pizzaImg') as File,
        pizzaPrices: []
    };
    await createPizza(updates);
    return redirect(`/`);
};

export default function CreatePizza() {
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
                <label>
                    <span>Pizza Image</span>
                    <input
                        placeholder="PizzaImg"
                        aria-label="PizzaImg"
                        type="file"
                        name="pizzaImg"
                        multiple={false}
                    />
                </label>
                <button type="submit">Save</button>
            </Form>
        </>
    );
}