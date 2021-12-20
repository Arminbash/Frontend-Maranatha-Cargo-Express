import React from "react";
import PrincipalStyle from "../../Styles/PrincipalStyle";
import { Drawer, Divider,Avatar,Typography } from "@material-ui/core";
import Lista from "./Lista";
import img from "../../img/150-9.jpg"
import { useStateValue } from "../../contexto/store";
const Contenedor = (props) => {
  const classes = PrincipalStyle();
  const [{sesionUsuario}, dispatch] = useStateValue();
  return (
    <Drawer
     className={classes.drawer} 
     anchor="left" 
     variant={props.variant}
     classes={{paper:classes.drawerPaper}}
     open={props.open}
     onClose={props.onClose ? props.onClose : null}
     >
        <div className={classes.toolbar}>
          <div className={classes.avatar} >
          <Avatar src={img} variant="rounded">
            </Avatar>
             <Typography className={classes.link}>
             <div className={classes.toolbar}>
                { sesionUsuario ?
                  (sesionUsuario.autenticado ? sesionUsuario.usuario.nombreCompleto  : "no sesion") 
                  :"No sesion"}
            </div>
            </Typography>
          </div>
        </div>
        <Divider></Divider>
        <Lista></Lista>
    </Drawer>
  );
};

export default Contenedor;
