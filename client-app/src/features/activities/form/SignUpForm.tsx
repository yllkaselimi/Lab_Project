
import { Button, Form, Segment } from 'semantic-ui-react';
import { User } from '../../../app/models/user';

interface Props {
    handleSignUpClose: () => void;
}
 
export default function SignUpForm({handleSignUpClose}: Props) {

    return(
        <Segment clearing>
            <Form autoComplete='off'>
                <Form.Input placeholder='Name' name='name'/>
                <Form.Input placeholder='Surname' name='surname'/>
                <Form.Input placeholder='Email' name='email'/>
                <Form.Input placeholder='Password' name='password'/>
                <Form.Input placeholder='Age' name='age'/>
                <Button onClick={handleSignUpClose} floated='right' type='button' content='Cancel' />
                <Button onClick={handleSignUpClose} floated='left' type='button' content='Submit' color="pink" />
            </Form>
        </Segment>
    )


}
