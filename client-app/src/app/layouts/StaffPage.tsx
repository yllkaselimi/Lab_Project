import React, { useEffect, useState } from 'react';
import './styles.css';
import NavBar from './NavBar';
import { Button, Container, Divider, List } from 'semantic-ui-react';
import {v4 as uuid} from 'uuid';
import { Route, useLocation } from 'react-router-dom';
import { Staff } from '../models/staff';
import axios from 'axios';
import StaffDashboard from '../../features/staff/StaffDashboard';



function StaffPage() {
    const [staffs, setStaffs] = useState<Staff[]>([]);


useEffect(() =>{
    axios.get<Staff[]>('http://localhost:5000/api/StaffList').then(response => {
        setStaffs(response.data);
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
        } } /><div>
    </div>
    

    <Container style ={{marginTop: '7em'}}>
          <StaffDashboard staffs={staffs} />
      </Container>
    
    
    </>
    );
}

export default StaffPage;