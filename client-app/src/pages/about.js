import React from "react";
import { Button, Container, Divider } from "semantic-ui-react";
import NavBar from "../app/layouts/NavBar";
import ActivityDashboard from "../features/activities/dashboard/ActivityDashboard";

  
const About = () => {
 
    
  return (

  <><NavBar /><div>
        
          <Container textAlign='center'><h1>Fitness Star</h1></Container>
          
          <Container textAlign='justified'>
              <b><h2>about</h2></b>
              <Divider />
              <p>
              FitnessStar is an app that lets you create your own personal account to join activities online, buy our personalised fitness shirts and more..
              </p>     
          </Container>
      </div></>


  );
};
  
export default About;