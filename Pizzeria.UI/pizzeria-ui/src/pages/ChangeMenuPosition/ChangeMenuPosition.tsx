import styles from './ChangeMenuPosition.module.scss';
import { useCallback, useEffect, useState } from 'react';
import DataGrid, {
    Column, RowDragging, Scrolling, Sorting,
} from 'devextreme-react/data-grid';
import { CheckBox, CheckBoxTypes } from 'devextreme-react/check-box';
import { changePizzaDisplayOrdering, getPizzaForChangingDisplayOrder } from '../../services/pizzaService';
import { PizzaDisplayOrdering } from '../../interfaces/PizzaDisplayOrdering';

export default function ChangeMenuPosition() {
    const [pizzaList, setPizzaList] = useState<PizzaDisplayOrdering[]>([]);
    const [showDragIcons, setShowDragIcons] = useState(true);
    const [isModified, setModified] = useState(false);

    const onReorder = useCallback((e: any) => {
        const visibleRows = e.component.getVisibleRows();
        const newPizzaList: PizzaDisplayOrdering[] = [...pizzaList];

        const toIndex = newPizzaList.findIndex((item) => item.id === visibleRows[e.toIndex].data.id);
        const fromIndex = newPizzaList.findIndex((item) => item.id === e.itemData.id);

        newPizzaList.splice(fromIndex, 1);
        newPizzaList.splice(toIndex, 0, e.itemData);

        setPizzaList(newPizzaList);
        setModified(true);
    }, [pizzaList]);

    const onShowDragIconsChanged = useCallback((args: CheckBoxTypes.ValueChangedEvent) => {
        setShowDragIcons(args.value);
    }, []);

    useEffect(() => {
        const fenchData = async () => {
            var data = await getPizzaForChangingDisplayOrder();
            setPizzaList(data);
        };
        fenchData();
    }, []);

    async function onClickSaveHandler() {
        const pizzaListByDisplayOrder: PizzaDisplayOrdering[] = pizzaList.map((item, index) => {
            return { ...item, displayOrder: index++ };
        });
        await changePizzaDisplayOrdering(pizzaListByDisplayOrder);
        setModified(false);
    }

    return (
        <>
            <DataGrid
                height={440}
                dataSource={pizzaList}
                keyExpr="id"
                showBorders={true}
            >
                <RowDragging
                    allowReordering={true}
                    onReorder={onReorder}
                    showDragIcons={showDragIcons}
                />
                <Scrolling mode="virtual" />
                <Sorting mode="none" />
                <Column dataField="id" width={55} />
                <Column dataField="name" width={150} />
            </DataGrid>
            <div className={styles.options}>
                <div className={styles.caption}>Options</div>
                <button className={styles.saveBtn} disabled={!isModified} onClick={onClickSaveHandler}>Save New Order</button>
                <div className={styles.option}>
                    <CheckBox
                        value={showDragIcons}
                        text="Show Drag Icons"
                        onValueChanged={onShowDragIconsChanged}
                    />
                </div>
            </div>
        </>
    );
}