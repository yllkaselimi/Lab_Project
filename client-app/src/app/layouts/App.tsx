import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Activity } from '../models/activity';
import './styles.css';
import NavBar from './NavBar';

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
      <div id="body">
        <ul>
          {activities.map((activity: any) => (
            <li key={activity.id}>
              {activity.title}
            </li>
          ))}
        </ul>
      </div>
    </>
  );
  } 



export default App;
