import React from "react";
import { Container, Divider } from "semantic-ui-react";
import NavBar from "../app/layouts/NavBar";
import ActivityDashboard from "../features/activities/dashboard/ActivityDashboard";

  
const About = () => {
 
    
  return (

  <><NavBar /><div>
        
          <Container textAlign='center'>What is Fitness Star ?</Container>
          
          <Container textAlign='justified'>
              <b>about</b>
              <Divider />
              <p>
              FitnessStar is an app that lets you create your own personal account to join activities online, buy our personalised fitness shirts and more..
              </p>
              <p>
              Create your account today and and get 15% off your monthly gym membership.
              </p>
            
          </Container>
      </div></>


  );
};
  
export default About;