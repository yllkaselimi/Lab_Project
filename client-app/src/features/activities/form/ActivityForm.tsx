import React from 'react';
import { Button, Form, Segment } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';


interface Props {
   activity: Activity | undefined;
    closeForm: () => void;
}


export default function ActivityForm({activity, closeForm}: Props) {
    return(
        <Segment clearing>
            <Form>
                <Form.Input placeholder='Title' />
                <Form.Input placeholder='Date' />
                <Form.Input placeholder='Duration' />
                <Form.Input placeholder='EventCoordinator' />
                <Form.Input placeholder='NumberOfParticipants' />
                <Button floated='right' positive type='submit' content='Submit' />
                <Button onCLick={closeForm} floated='right' type='button' content='Cancel' />
            </Form>
        </Segment>
    )


}
