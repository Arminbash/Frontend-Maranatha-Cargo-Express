import React from "react";
import style from "../../Styles/AuthPageStyle";
import { Route, BrowserRouter,Routes } from "react-router-dom";
import Login from "./Login";
import RegistrarUsuario from "./RegistrarUsuario";
import Principal from "../Navegacion/Principal";
import { Typography, Grid, Link } from "@material-ui/core";
import { useStateValue } from "../../contexto/store";
const AuthPage = () => {
  const [{sesionUsuario}, dispatch] = useStateValue();
  return (
    <div style={style.div}>
      <div>
      { sesionUsuario ?
                  (sesionUsuario.autenticado ? "no" : <Grid container justifyContent="center" style={style.title}>
                  <Typography variant="h5" style={style.h1}>
                    Maranatha Cargo Express
                  </Typography>
                </Grid> ) 
                  : <Grid container justifyContent="center" style={style.title}>
                  <Typography variant="h5" style={style.h1}>
                    Maranatha Cargo Express
                  </Typography>
                </Grid>}
       
        <BrowserRouter>
          <Routes>
            <Route exact path="/" element={<Login/>} />
            <Route path="/auth/Registrar" component={RegistrarUsuario} />
            <Route path="/Principal" element={<Principal/>} />
          </Routes>
        </BrowserRouter>
      </div>
      { sesionUsuario ?
                  (sesionUsuario.autenticado ? "no;":<footer>
                  <Grid container justifyContent="center" style={style.footer}>
                    <div>
                      <div>
                        <Link style={style.link} href="/" variant="body1">
                          About
                        </Link>
                        <Link style={style.link} href="/" variant="body1">
                          Contact
                        </Link>
                        <Link style={style.link} href="/" variant="body1">
                          Contact Us
                        </Link>
                      </div>
                    </div>
                  </Grid>
                </footer>):<footer>
        <Grid container justifyContent="center" style={style.footer}>
          <div>
            <div>
              <Link style={style.link} href="/" variant="body1">
                About
              </Link>
              <Link style={style.link} href="/" variant="body1">
                Contact
              </Link>
              <Link style={style.link} href="/" variant="body1">
                Contact Us
              </Link>
            </div>
          </div>
        </Grid>
      </footer>} 
      
    </div>
  );
};

export default AuthPage;
