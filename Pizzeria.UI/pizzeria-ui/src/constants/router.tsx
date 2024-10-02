import { createBrowserRouter } from 'react-router-dom';
import Root from '../components/Root/Root';
import Error from '../pages/Error/Error';
import Menu from '../pages/Menu/Menu';
import
CreatePizza,
{ action as createPizzaAction }
    from '../pages/CreatePizza/CreatePizza';
import ChangeMenuPosition from '../pages/ChangeMenuPosition/ChangeMenuPosition';

export const ROUTER = createBrowserRouter([{
    path: "/",
    element: <Root />,
    errorElement: <Error />,
    children: [
        {
            index: true,
            path: "/",
            element: <Menu />
        },
        {
            path: "createPizza",
            element: <CreatePizza />,
            action: createPizzaAction
        },
        {
            path: "changeMenuPosition",
            element: <ChangeMenuPosition />
        },
    ]
}]);