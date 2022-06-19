import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Activity } from '../models/activity';
import './styles.css';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import { Container } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined); 
  const [editMode, setEditMode] = useState(false);
  

  useEffect(() => {
    axios.get(`/getAll`).then(response =>{ 
      console.log('RESPONSE YLLKA: ', response); 
      setActivities(response.data);
    })
  }, [])

  function handleSelectActivity(id: string) {
    setSelectedActivity(activities.find(x => x.id === id));
  }

  function handleCancelSelectActivity(){
    setSelectedActivity(undefined);
  }

  function handleFormOpen(id?: string) {
    id? handleSelectActivity(id) : handleCancelSelectActivity();
    setEditMode(true);

  }

  function handleFormClose(){
    setEditMode(false);
  }


  
  return (
    <>
      <NavBar openForm={handleFormOpen}/>
        <Container>
     <ActivityDashboard activities={activities} 
     selectedActivity={selectedActivity}
     selectActivity={handleSelectActivity}
     cancelSelectActivity={handleCancelSelectActivity}
     editMode={editMode}
     openForm={handleFormOpen}
     closeForm={handleFormClose}
     />
     </Container>

    </>
  );
  } 



export default App;
