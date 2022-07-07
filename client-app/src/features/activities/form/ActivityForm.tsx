import React, { ChangeEvent, useState } from 'react';
import { Button, Form, Segment } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';


interface Props {
   activity: Activity | undefined;
    closeForm: () => void;
    createOrEdit: (activity: Activity) => void;
}


export default function ActivityForm({activity: selectedActivity, closeForm, createOrEdit}: Props) {

    const initialState = selectedActivity ?? {
    id: '',
    title: '',
    date: '',
    duration: '',
    eventCoordinator: '',
    numberOfParticipants: ''
    }

    const [activity, setActivity] = useState(initialState);

    function handleSubmit(){
        createOrEdit(activity);

    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        const {name, value} = event.target;
        setActivity({...activity, [name]: value})

    }

    return(
        <Segment clearing>
            <Form onSubmit={handleSubmit} autoComplete='off'>
                <Form.Input placeholder='Title' value={activity.title} name='title' onChange={handleInputChange}/>
                <Form.Input placeholder='Date' value={activity.date} name='Date' onChange={handleInputChange}/>
                <Form.Input placeholder='Duration' value={activity.duration} name='Duration' onChange={handleInputChange}/>
                <Form.Input placeholder='EventCoordinator' value={activity.eventCoordinator} name='Event Coordinator' onChange={handleInputChange}/>
                <Form.Input placeholder='NumberOfParticipants' value={activity.numberOfParticipants} name='Number of Participants' onChange={handleInputChange}/>
                <Button floated='right' positive type='submit' content='Submit'/>
                <Button onClick={closeForm} floated='right' type='button' content='Cancel' />
            </Form>
        </Segment>
    )


}
