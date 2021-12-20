import React from 'react';
import {
    Divider,
    List,
    ListItem,
    ListItemIcon,
    ListItemText,
    Icon
  } from "@material-ui/core";
const Lista = () => {
    return (
        <div>
           <List component='nav'>
                  <ListItem button>
                  <ListItemIcon>
                      <Icon>person</Icon>
                    </ListItemIcon>
                    <ListItemText>Usuario</ListItemText>
                  </ListItem>
              <Divider/>
                  <ListItem button>
                  <ListItemIcon>
                      <Icon>person</Icon>
                    </ListItemIcon>
                    <ListItemText>Usuario</ListItemText>
                  </ListItem>
           </List>
        </div>
    );
};

export default Lista;