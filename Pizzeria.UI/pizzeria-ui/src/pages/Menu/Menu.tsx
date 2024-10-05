import styles from './Menu.module.scss';
import { useEffect, useState } from "react";
import { getAllPizzas } from "../../services/menuService";
import PizzaItem from "../../components/PizzaItem/PizzaItem";
import type { Pizza } from '../../interfaces/Pizza';
import BasketModal from "../../components/BasketModal/BasketModal";

export default function Menu() {
    const [data, setData] = useState<Pizza[]>([]);
    const [basketItems, setBasketItems] = useState<Pizza[]>([]);
    const [isModal, setModal] = useState(false);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getAllPizzas();
            setData(response);
            setLoading(false);
        };
        fetchData();
    }, []);

    return (
        <>
            {loading ? (
                <span className={styles.loader}></span>
            ) : (
                <>
                    <ul className={styles.ulPizzas}>
                        {data.map((pizza) => (
                            <li className={styles.pizza} key={pizza.id}>
                                <PizzaItem
                                    data={pizza}
                                    onBuy={() => setBasketItems([...basketItems, pizza])}
                                />
                            </li>
                        ))}
                    </ul>
                    <BasketModal
                        basketItems={basketItems}
                        isModal={isModal}
                        onBasketBtnClick={() => setModal(!isModal)}
                    />
                </>
            )}
        </>
    );
}