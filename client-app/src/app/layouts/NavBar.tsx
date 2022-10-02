import React, {useState} from 'react';
import { Button, Container, Menu, MenuItem} from 'semantic-ui-react'
import {
    Link,
  } from "react-router-dom";
import * as FaIcons from "react-icons/fa";
import * as AiIcons from "react-icons/ai";
import { SideBarData } from './SideBarData';
import { User } from '../../app/models/user';

interface Props {
    openForm: () => void;
    signUp: () => void;
    login: () => void;
    loggedIn: any;
}
    
export default function NavBar({openForm, signUp, login, loggedIn} : Props) {
    const [sidebar, setSideBar] = useState(false)

    const showSideBar = () => setSideBar(!sidebar)
    return (
        <Menu inverted fixed='top'>
            <Container>
                { loggedIn != "" ?  
                <div className='navbar'>
                    <button onClick={showSideBar}>
                        <FaIcons.FaBars>
                        
                        </FaIcons.FaBars>
                    </button>
                </div> : <></>
                }
                
                <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
                    <ul className='nav-menu-items'>
                       <li className="navbar-toggle">
                        <button onClick={showSideBar} className='menu-bars'>
                            <AiIcons.AiOutlineClose/>
                        </button>
                        </li> 
                        {SideBarData.map((item, indexi) => {
                            return (
                                <li key={indexi} className={item.cName}>
                                    <Link to={item.path}>
                                        {item.title}
                                    </Link>
                                </li>
                            )
                        })}
                    </ul>
                </nav>

                <Menu.Item header>
                    <img src="/images/death-star.png" alt="logo" style={{marginRight: '10px'}}/>
                    
                    <Button>
                        <li>
                            <Link to = "/">Fitness Star</Link>
                        </li>
                    </Button>
                </Menu.Item>
        
                {    loggedIn != "" ?            
                <Menu.Item> 
                    <Button onClick={openForm} content='Create Activity' color='violet'/> 
                </Menu.Item> : <></>
                }
                <Menu.Item>
                    <Button onClick={signUp} content='Sign Up' color='blue'/>
                </Menu.Item>
                <Menu.Item>
                    <Button onClick={login} content="Login" color='blue'/>
                </Menu.Item>
                <div className={loggedIn == "" ? 'hidden' : 'email'}>
                    <Button content={loggedIn != "" ? loggedIn : ''} color='blue'/>
                </div>      
            </Container>
        </Menu>
    )
}


