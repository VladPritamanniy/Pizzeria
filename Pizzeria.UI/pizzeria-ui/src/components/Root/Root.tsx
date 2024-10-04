import { ROUTES } from '../../constants/ROUTES.ts';
import styles from './Root.module.scss'
import {
  NavLink,
  Outlet
} from "react-router-dom";

export default function Root() {
  return (
    <>
      <div className={styles.sidebar}>
        <img className={styles.pizzaImg} src='/sidebar-pizza.png' />
        <nav>
          <ul>
            {ROUTES.map(route => (
              <li key={route.id}>
                <NavLink
                  to={route.value}
                  className={({ isActive }) =>
                    isActive
                      ? styles.active
                      : ""
                  }
                >
                  {route.name}
                </NavLink>
              </li>
            ))}
          </ul>
        </nav>
      </div>
      <div className={styles.content}>
        <Outlet />
      </div>
    </>
  )
}