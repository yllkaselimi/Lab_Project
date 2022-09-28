import ReactDOM from 'react-dom/client';
import './app/layouts/styles.css';
import 'semantic-ui-css/semantic.min.css'
import App from './app/layouts/App';
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Link,
  BrowserRouter
} from "react-router-dom";
import About from './pages/about';
import EquipmentPage from './app/layouts/EquipmentPage';



const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
const YllkaRoutes = () => {
  return(
   <BrowserRouter>
    
    <div>
      <Routes>
        <Route path="/about" element={<About/>} />
        <Route path="/second" element={<div>yllka</div>} />
        <Route path="/" element={ <App />} />
        <Route path="/equipment" element={<EquipmentPage />} />
      </Routes>
    </div>
   </BrowserRouter>
  )
}
root.render(
    <YllkaRoutes />
 
);



