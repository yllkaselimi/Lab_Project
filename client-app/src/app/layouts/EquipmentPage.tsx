import React, { useEffect, useState } from 'react';
import './styles.css';
import NavBar from './NavBar';
import { Button, Container, Divider, List } from 'semantic-ui-react';
import {v4 as uuid} from 'uuid';
import { Route, useLocation } from 'react-router-dom';
import { Equipment } from '../models/equipments';
import axios from 'axios';
import EquipmentDashboard from '../../features/equipments/equipmentDashboard/EquipmentDashboard';


function EquipmentPage() {
    const [equipments, setEquipments] = useState<Equipment[]>([]);


useEffect(() =>{
    axios.get<Equipment[]>('http://localhost:5000/api/EquipmentList').then(response => {
        setEquipments(response.data);
    }
    )
} )


    return(

        <><NavBar openForm={function (): void {
            throw new Error('Function not implemented.');
        } } signUp={function (): void {
            throw new Error('Function not implemented.');
        } } login={function (): void {
            throw new Error('Function not implemented.');
        } } loggedIn=""  /><div>
    </div>
      
      <Container style ={{marginTop: '7em'}}>
          <EquipmentDashboard equipments={equipments} />
      </Container>
    
    </>

    );
}

export default EquipmentPage;