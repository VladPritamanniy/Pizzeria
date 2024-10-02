import styles from './BasketModal.module.scss';
import BasketItem from '../../components/BasketItem/BasketItem';
import type { Pizza } from '../../interfaces/Pizza';

interface Props {
    basketItems: Pizza[],
    isModal: boolean,
    onBasketBtnClick: () => void
}

export default function BasketModal({ basketItems, isModal, onBasketBtnClick }: Props) {
    return (
        <div className={styles.basketArea}>
            <div
                className={isModal
                    ? `${styles.basketModal} ${styles.active}`
                    : styles.basketModal}
            >
                <label>Basket</label>
                <hr />
                <ul className={styles.content}>
                    {basketItems.map((item) => (
                        <li key={item.id}>
                            <BasketItem data={item} />
                        </li>
                    ))}
                </ul>
            </div>
            <button className={styles.basketBtn} onClick={onBasketBtnClick}>
                <img className={styles.basketImg} src='/basket-white.png' />
                <p className={styles.countBasketItems}>{basketItems.length}</p>
            </button>
        </div>
    )
}