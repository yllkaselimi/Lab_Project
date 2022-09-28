import React from 'react';
import { Button, Card } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';


interface Props {
    activity: Activity;
    cancelSelectActivity: () => void;
    openForm: (id: string) => void;
}

export default function ActivityDetails({activity, cancelSelectActivity, openForm}: Props) {
     
    return(
        <Card fluid>
            <Card.Content>
            <Card.Header>{activity.title}</Card.Header>
            <Card.Meta>
             {activity.date}
            </Card.Meta>
            <Card.Description>
                Insert Description
            </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button onClick={() => openForm(activity.id)} basic color='violet' content='Edit' />
                <Button onClick={cancelSelectActivity} basic color='violet' content='Cancel'/>

            </Card.Content>
        </Card>

    )

}