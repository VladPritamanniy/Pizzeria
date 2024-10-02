import type { Pizza } from "../../interfaces/Pizza";

interface Props {
    data: Pizza;
}

export default function BasketItem({ data }: Props) {
    console.log(data);
    return (
        <>
            <div>{data.name}</div>
        </>
    )
}
