import React from 'react';
import { Button, Item, Segment } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';

interface Props {
    activities: Activity[];
}

export default function ActivityList({activities}: Props) {

    return (
        <Segment>
            <Item.Group divided>
                {activities.map(activity => (
                    <Item key={activity.id}>
                        <Item.Content>
                            <Item.Header as='a'>{activity.title} </Item.Header>
                            <Item.Meta>{activity.date}</Item.Meta>
                            <Item.Description>
                                <div>{activity.duration}</div>
                                <div>{activity.eventCoordinator}</div>
                                <div> Available spots: {activity.numberOfParticipants}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated='right' content='View' color='violet'/>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>

    )
}