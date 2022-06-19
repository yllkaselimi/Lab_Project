import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Activity } from '../models/activity';
import './styles.css';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import { Container } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get(`/getAll`).then(response =>{
      console.log('RESPONSE YLLKA: ', response);
      setActivities(response.data);
    })
  }, [])

  
  return (
    <>
      <NavBar/>
        <Container>
     <ActivityDashboard activities={activities} />
     </Container>

    </>
  );
  } 



export default App;
