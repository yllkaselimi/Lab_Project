import React, { useEffect, useState } from 'react';
import { Activity } from '../models/activity';
import './styles.css';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import { Container } from 'semantic-ui-react';
import {v4 as uuid} from 'uuid';
import {ActivitiesService} from '../api/agent';


function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined); 
  const [editMode, setEditMode] = useState(false);
  const [submitting, setSubmitting] = useState(false);
  const [signUp, setSignUp] = useState(false);


  useEffect(() => {
    ActivitiesService.Activities.list().then((response: any) =>{ 
      console.log('RESPONSE YLLKA: ', response); 
      setActivities(response);
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

  function handleSignUp(){
    setSignUp(true);
  }

  function handleSignUpClose(){
    setSignUp(false);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleCreateOrEditActivity(activity: Activity){
    setSubmitting(true);
    if(activity.id) {
      ActivitiesService.Activities.update(activity).then(() => {
      setActivities([...activities.filter(x => x.id !== activity.id), activity ])
      setSelectedActivity(activity);
      setEditMode(false);
      setSubmitting(false);
    
      })
    } else {
      activity.id = uuid();
      ActivitiesService.Activities.create(activity).then(() => {
      setActivities([...activities, activity]);
      setSelectedActivity(activity);
      setEditMode(false);
      setSubmitting(false);
      })
    }
  }

  function handleDeleteActivity(id: string) {
    const response = ActivitiesService.deleteActivity(id);
    console.log('Response: ', response);
    setActivities([...activities.filter(x => x.id !== id)])
  }


  
  return (
 
    <>
      
      <NavBar openForm={handleFormOpen} signUp={handleSignUp} />
        <Container>
     <ActivityDashboard 
     activities={activities} 
     selectedActivity={selectedActivity}
     selectActivity={handleSelectActivity}
     cancelSelectActivity={handleCancelSelectActivity}
     editMode={editMode}
     openForm={handleFormOpen}
     closeForm={handleFormClose}
     createOrEdit={handleCreateOrEditActivity}
     deleteActivity={handleDeleteActivity}
     signUp={signUp}
     handleSignUpClose={handleSignUpClose}
     />
     </Container>


    </>
    

  
  );
  } 
 



export default App;
