import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Activity } from '../models/activity';
import './styles.css';

const baseURL = 'http://localhost:5000';
function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get(`${baseURL}/getAll`).then(response =>{
      console.log('RESPONSE YLLKA: ', response);
      setActivities(response.data);
    })
  }, [])

  useEffect(() => {
    axios.get(`${baseURL}/5fcdba4c-b4da-4749-8d76-4d1037a4750a`).then(response =>{
      console.log('Activity with id 2: ', response.data);
    })
  }, [])

  return (
    <div>
      
    <ul>
      {activities.map((activity: any) => (
        <li key={activity.id}>
          {activity.title}
        </li>
     
      ))}
    </ul>
    </div>
  );
}

export default App;
