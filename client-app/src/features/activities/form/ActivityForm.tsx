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
            <Form autoComplete='off'>
                <Form.Input placeholder='Title' value={activity.title} name='title' onChange={handleInputChange}/>
                <Form.Input placeholder='Date' value={activity.date} name='date' onChange={handleInputChange}/>
                <Form.Input placeholder='Duration' value={activity.duration} name='duration' onChange={handleInputChange}/>
                <Form.Input placeholder='EventCoordinator' value={activity.eventCoordinator} name='eventCoordinator' onChange={handleInputChange}/>
                <Form.Input placeholder='NumberOfParticipants' value={activity.numberOfParticipants} name='numberOfParticipants' onChange={handleInputChange}/>
                <Button onClick={handleSubmit} floated='right' type='submit' content='Submit' color='pink'/>
                <Button onClick={closeForm} floated='right' type='button' content='Cancel' />
            </Form>
        </Segment>
    )


}
