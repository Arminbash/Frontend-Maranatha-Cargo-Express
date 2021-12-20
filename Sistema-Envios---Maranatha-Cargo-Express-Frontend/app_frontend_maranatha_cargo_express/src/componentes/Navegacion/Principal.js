import {React,useState} from 'react';
import PrincipalStyle from "../../Styles/PrincipalStyle";
import {Hidden} from "@material-ui/core";
import MenuAppBar from './MenuAppBar';
import Contenedor from './Contenedor';
import RegistrarUsuario from '../login/RegistrarUsuario';
const Principal = () => {
    const classes = PrincipalStyle();
     const [open, setOpen] = useState(false)
     const accionOpen = () => {
         setOpen(!open)
     }
    return (
        <div className={classes.root}>
           <MenuAppBar accionOpen={accionOpen} ></MenuAppBar>
           <Hidden xsDown>
           <Contenedor
           variant="permanent"
           open={true}
           >
           </Contenedor>
           </Hidden>
           <Hidden smUp>
           <Contenedor
           variant="temporary"
           open={open}
            onClose={accionOpen}
           >
           </Contenedor>
           </Hidden>
           <div className={classes.content}>
               <div className={classes.toolbar}>
               </div>
                <RegistrarUsuario></RegistrarUsuario>
           </div>
        </div>
    );
};

export default Principal;