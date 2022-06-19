import React from 'react'
import { Button, Container, Menu } from 'semantic-ui-react'
    
function NavBar() {
    return (
        
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src="/images/death-star.png" alt="logo" style={{marginRight: '10px'}}/>
                    FitnessStar
                </Menu.Item>
                <Menu.Item name='Activities'/> 
                    
                <Menu.Item>
                    <Button positive content='Create Activity'/>
                </Menu.Item>
            </Container>
        </Menu>
    )
}

export default NavBar