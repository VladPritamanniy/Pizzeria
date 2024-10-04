import { SizeWithPrice } from '../../interfaces/SizeWithPrice';
import styles from './SizeItem.module.scss';

interface Props{
    size: SizeWithPrice,
    index: number,
    onChangeHandler: (index: number, updatedSize: SizeWithPrice) => void
}

export default function SizeItem({size, index, onChangeHandler}:Props){
    return(
        <>
            <div key={size.id} className={styles.sizeItem}>
                <span className={styles.sizeLabel}>{size.name}:</span>
                <input 
                    type="number"
                    value={size.price || ''} 
                    onChange={e => onChangeHandler(index, { ...size, price: parseFloat(e.target.value) })}  
                    className={styles.sizeInput}
                    min="0"
                    step="0.01"
                />
                <input 
                    type="hidden" 
                    value={size.id} 
                    className={styles.hiddenInput}
                />
            </div>
        </>
    )
}