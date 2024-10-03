import { SizeWithPrice } from "../../interfaces/SizeWithPrice";
import SizeItem from './SizeItem';

interface Props {
    sizeList: SizeWithPrice[],
    onChangeHandler: (index: number, updatedSize: SizeWithPrice) => void
}

export default function SizeList({ sizeList, onChangeHandler }: Props) {
    return(
        <>
            {sizeList.map((item, index) => (
                <SizeItem
                    key={item.id}
                    size={item}
                    onChangeHandler={onChangeHandler}
                    index={index}
                />
            ))}
        </>
    )
}