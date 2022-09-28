import React from 'react';
import { Grid, GridColumn, List} from 'semantic-ui-react';
import { Equipment } from '../../../app/models/equipments';
import EquipmentList from '../EquipmentList';



interface Props {
    equipments: Equipment[];
}

export default function EquipmentDashboard({equipments}: Props) {
    return (

        <Grid>
            <Grid.Column width='10'>
                <EquipmentList equipments={equipments}/>
            </Grid.Column>        
       </Grid>
    )
}
