import React from 'react';
import { Button, Item, Label, Segment } from 'semantic-ui-react';
import { Equipment } from '../../app/models/equipments';


interface Props {
    equipments: Equipment[];
}

export default function EquipmentList({equipments}: Props) {

    return (
        <Segment>
            <Item.Group divided>
                {equipments.map(equipment => (
                    <Item key={equipment.id}>
                        <Item.Content>
                            <Item.Header as='a'>{equipment.type} </Item.Header>
                            <Item.Meta>{equipment.category}</Item.Meta>
                            <Item.Description>
                                <div>{equipment.description}</div>
                                <div>{equipment.availability}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated='right' content='View' color='violet'></Button>
                                <Label basic content={equipment.category}></Label>
                            </Item.Extra>
                        

                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>

    )
}