
import { Button, Form, Segment } from 'semantic-ui-react';

interface Props {
    handleLoginClose: () => void;
}
 
export default function LoginForm({handleLoginClose}: Props) {

    return(
        <Segment clearing>
            <Form autoComplete='off'>
                <Form.Input placeholder='Email' name='email'/>
                <Form.Input placeholder='Password' name='password'/>
                <Button onClick={handleLoginClose} floated='right' type='button' content='Cancel' />
                <Button onClick={handleLoginClose} floated='left' type='button' content='Submit' color="pink" />
            </Form>
        </Segment>
    )


}