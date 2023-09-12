import { Provider } from "./Context";
import React from "react";
import ReactDOM from 'react-dom/client'
import { BrowserRouter } from 'react-router-dom'
import App from './router/App'
import './styles/global.scss'
import 'sweetalert2/src/sweetalert2.scss'


ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <Provider>
        <App />
      </Provider>
    </BrowserRouter>
  </React.StrictMode>,
)
