import { useState } from 'react';
import styles from './PizzaItem.module.scss';
import type { Pizza } from '../../interfaces/Pizza';
import type { PizzaPrice } from '../../interfaces/PizzaPrice';

interface Props {
    data: Pizza;
    onBuy: () => void;
}

export default function PizzaItem({ data, onBuy }: Props) {
    const [selectedSize, setSelectedSize] = useState<number>(0);
    const [price, setPrice] = useState<number>(0);

    function selectSizeHandler(item: PizzaPrice) {
        setSelectedSize(item.id);
        setPrice(item.price.value);
    }

    return (
        <>
            <img
                className={styles.pizzaImg}
                src={`https://res.cloudinary.com/dlytf9rwa/image/upload/v1725876030/${data.publicImageId}.avif`}
            />
            <h3 className={styles.name}>{data.name}</h3>
            <p className={styles.ingredients}>
                {data.pizzaIngredients.map((item, index) => (
                    <span key={item.ingredient.id}>
                        {item.ingredient.name}
                        {index === data.pizzaIngredients.length - 1 ? '.' : ', '}
                    </span>
                ))}
            </p>
            <div className={styles.sizes}>
                {data.pizzaPrices
                    .slice()
                    .sort((a, b) => a.id - b.id)
                    .map((item) => (
                        <p
                            className={selectedSize === item.id ? `${styles.size} ${styles.active}` : styles.size}
                            key={item.id}
                            onClick={() => selectSizeHandler(item)}
                        >
                            {item.size.name}
                        </p>
                    ))}
            </div>
            <div className={styles.price}>
                <p className={styles.value}>
                    {price > 0 ? `${price} $` : 'Select size'}
                </p>
                <button
                    disabled={selectedSize === 0}
                    className={styles.buyBtn}
                    onClick={onBuy}
                >
                    <img className={styles.basketImg} src='/basket-white.png' alt='Basket' />
                    Buy
                </button>
            </div>
        </>
    );
}