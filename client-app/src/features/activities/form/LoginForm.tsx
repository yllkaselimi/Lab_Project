
import { Button, Form, Segment } from 'semantic-ui-react';
import axios, { AxiosResponse } from 'axios';
import React, { ChangeEvent, useState } from 'react';
import { User } from '../../../app/models/user';



interface Props {
    handleLoginClose: () => void;
    user: User;
    setUser: (user: User) => void;
    loggedIn: any
    setLoggedIn: any
}
 
export default function LoginForm({user, setUser, handleLoginClose, loggedIn, setLoggedIn}: Props) {

    const initialState =  {
        email: '',
        password: ''
    }

    function handleLoginSubmit(){
        console.log(user)
        const options = {
            method: 'POST',
            url: 'http://localhost:5000/api/login',
            headers: {'Content-Type': 'application/json'},
            data: user
          };
          console.log(options);
        axios.request(options).then(function (response) {
            if(response.data){
                alert("Logged In")
                setLoggedIn(response.data.email)
                handleLoginClose();
            }else{
                console.log(response)
                alert("Wrong Password" );
                setUser(initialState);
            }
            }).catch(function (error) {
                console.error(error);
            });

    }


    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        const {name, value} = event.target;
        setUser({...user, [name]: value})
    }
    

    return(
        <Segment clearing >
            <Form autoComplete='off'>
                <Form.Input placeholder='Email' name='email' onChange={handleInputChange}/>
                <Form.Input placeholder='Password' name='password' type="password" onChange={handleInputChange}/>
                <Button onClick={handleLoginClose} floated='right' type='button' content='Cancel' />
                <Button onClick={handleLoginSubmit} floated='left' type='button' content='Submit' color="pink" />
            </Form>
        </Segment>
    )


}