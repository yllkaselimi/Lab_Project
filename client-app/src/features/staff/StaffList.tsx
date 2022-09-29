import React from 'react';
import { Button, CardGroup, Item, Label, Segment } from 'semantic-ui-react';
import { Staff } from '../../app/models/staff';

  

interface Props {
    staffs: Staff[];
}

export default function StaffList({staffs}: Props) {

    return (
 

        <Segment>
        <Item.Group divided>
            {staffs.map(staff => (
                <Item key={staff.id}>
                    <Item.Content>
                        <Item.Header as='a'>{staff.name} </Item.Header>
                        <Item.Meta>{staff.trainer}</Item.Meta>
                        <Item.Description>
                            <div>{staff.description}</div>
                            <div>{staff.email}</div>
                        </Item.Description>
                        <Item.Extra>
                            <Button floated='right' content='View' color='violet'></Button>
                        </Item.Extra>
                    

                    </Item.Content>
                </Item>
            ))}
        </Item.Group>
    </Segment>

    )
}
    