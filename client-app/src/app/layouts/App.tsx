import React, { useEffect, useState } from 'react';
import { Activity } from '../models/activity';
import './styles.css';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import { Button, Container } from 'semantic-ui-react';
import {v4 as uuid} from 'uuid';
import {ActivitiesService} from '../api/agent';
import { Route, useLocation } from 'react-router-dom';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined); 
  const [editMode, setEditMode] = useState(false);
  const [submitting, setSubmitting] = useState(false);
  const [signUp, setSignUp] = useState(false);
  const [login, setLogin] = useState(false);
  const [loggedIn, setLoggedIn] = useState('');
  const initialState =  {
    email: '',
    password: '',
    role: ''
}
  const [user, setUser] = useState(initialState);


  useEffect(() => {
    ActivitiesService.Activities.list().then((response: any) =>{ 
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

  function handleLogin(){
    setLogin(true);
  }

  function handleLoginClose(){
    setLogin(false);
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
      if(user?.role === "admin"){
        ActivitiesService.Activities.create(activity).then(() => {
          setActivities([...activities, activity]);
          setSelectedActivity(activity);
          setEditMode(false);
          setSubmitting(false);
          })
      }else{
        alert("You don't have permission to create Activities")
      }
    }
  }

  function handleDeleteActivity(id: string) {
    const response = ActivitiesService.deleteActivity(id);
    setActivities([...activities.filter(x => x.id !== id)])
  }

  

  return (
    <>
      <NavBar openForm={handleFormOpen} signUp={handleSignUp} login={handleLogin} loggedIn={loggedIn}/>
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
     login={login}
     handleLoginClose={handleLoginClose}
     user={user}
     
     setUser={setUser}
     loggedIn={loggedIn}
     setLoggedIn={setLoggedIn}
    />

     </Container>

    </>
  );
  } 

      export default App;
