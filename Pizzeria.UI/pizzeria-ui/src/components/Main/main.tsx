import './index.css';
import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { RouterProvider } from 'react-router-dom';
import { ROUTER } from '../../constants/ROUTER.tsx';
import 'devextreme/dist/css/dx.light.css';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={ROUTER} />
  </StrictMode>
)
