import React from 'react';
import { Grid, GridColumn, List} from 'semantic-ui-react';
import { Staff } from '../../app/models/staff';
import StaffList from './StaffList';




interface Props {
    staffs: Staff[];
}

export default function StaffDashboard({staffs}: Props) {
    return (

        <Grid>
            <Grid.Column width='10'>
                <StaffList staffs={staffs}/>
            </Grid.Column>        
       </Grid>
    )
}
