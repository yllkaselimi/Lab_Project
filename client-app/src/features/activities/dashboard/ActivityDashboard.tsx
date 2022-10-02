import React from 'react';
import { Grid, GridColumn} from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';
import ActivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';
import ActivityList from './ActivityList';
import SignUpForm from '../form/SignUpForm';
import LoginForm from '../form/LoginForm';
import { User } from '../../../app/models/user';


interface Props {
    activities: Activity[];
    selectedActivity: Activity | undefined;
    selectActivity: (id: string) => void;
    cancelSelectActivity: () => void;
    editMode: boolean;
    openForm: (id: string) => void;
    closeForm: () => void;
    createOrEdit: (activity: Activity) => void;
    deleteActivity: (id: string) => void;
    signUp: boolean;
    handleSignUpClose: () => void;
    login: boolean;
    handleLoginClose: () => void;
    user: User;
    setUser: (user: User) => void;
    loggedIn: String;
    setLoggedIn: any;
}

export default function ActivityDashboard({activities, selectedActivity, selectActivity, cancelSelectActivity,
          editMode, openForm, closeForm, createOrEdit, deleteActivity, signUp, handleSignUpClose, login, handleLoginClose, user, setUser, loggedIn, setLoggedIn}: Props) {
    
    let activity = <></>;       
    if (loggedIn == "") {
        activity = <></>;
    } else {
        activity = <ActivityList activities={activities} 
        selectActivity={selectActivity} 
        deleteActivity={deleteActivity}
        />;
    }

    return (

        <Grid>
            <Grid.Column width='10'>
            {activity}
            </Grid.Column>
            <GridColumn width='6'>
                {selectedActivity && !editMode &&
                <ActivityDetails 
                activity={selectedActivity} 
                cancelSelectActivity={cancelSelectActivity} 
                openForm={openForm}

                /> }
                {editMode &&
                <ActivityForm
                 closeForm={closeForm}
                 activity={selectedActivity}
                 createOrEdit={createOrEdit}
                />}
                {signUp && 
                <SignUpForm
                    handleSignUpClose={handleSignUpClose}
                />
                }
                {login && 
                <LoginForm
                    user={user}
                    setUser={setUser}
                     handleLoginClose={handleLoginClose}
                     loggedIn = {loggedIn}
              
                     setLoggedIn = {setLoggedIn}
                 />
                }
            </GridColumn>
        </Grid>
    )
}