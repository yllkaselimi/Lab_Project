import React, {Component} from 'react'
import { Button, Container, Menu, MenuItem } from 'semantic-ui-react'
import {
    BrowserRouter as Router,
    Route,
    Routes,
    Link,
    BrowserRouter
  } from "react-router-dom";






interface Props {
    openForm: () => void;
    signUp: () => void;
    login: () => void;
}
    
export default function NavBar({openForm, signUp, login} : Props) {

    return (

       
      
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src="/images/death-star.png" alt="logo" style={{marginRight: '10px'}}/>
                    
                    <Button>
                <li><Link to = "/">Fitness Star</Link></li>
                </Button>
                </Menu.Item>

                <MenuItem>
                <Button>
                <li><Link to = "/about">About</Link></li>
                </Button>
                </MenuItem>
            
                <Menu.Item> 
                  
                    <Button onClick={openForm} content='Create Activity' color='violet'/>
                   
                </Menu.Item>
                <Menu.Item>
                    <Button onClick={signUp} content='Sign Up' color='blue'/>
                </Menu.Item>
                <Menu.Item>
                    <Button onClick={login} content="Login" color='blue'/>
                </Menu.Item>
        
            </Container>
        </Menu>


    )
}


