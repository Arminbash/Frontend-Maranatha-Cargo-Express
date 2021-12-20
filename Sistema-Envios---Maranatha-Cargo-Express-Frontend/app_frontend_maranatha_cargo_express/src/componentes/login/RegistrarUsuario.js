import React, { useState } from "react";
import {
  Avatar,
  Container,
  Grid,
  Card,
  Icon,
  Typography,
  TextField,
  Button
} from "@material-ui/core";
import useStyles from "../../Styles/useStyles";
import { Link } from "react-router-dom";

const clearUsuario = {
  nombre: "",
  apellidos: "",
  email: "",
  password: ""
};

const RegistrarUsuario = () => {
  const classes = useStyles();
  const [usuario, setUsuario] = useState({
    nombre: "",
    apellidos: "",
    email: "",
    password: ""
  });

  const handleChange = e => {
    const { name, value } = e.target;
    setUsuario(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const guardarUsuario = () => {
    console.log(usuario);
    setUsuario(clearUsuario);
  };
  return (
    <Container className={classes.containermt}>
      <Grid container justifyContent="center">
        <Grid item lg={6} md={8}>
          <Card className={classes.card} align="center">
            <Avatar className={classes.avatar}>
              <Icon className={classes.icon}>person_add</Icon>
            </Avatar>
            <Typography variant="h5" color="primary">
              Registar Usuario
            </Typography>
            <form className={classes.form} onSubmit={e => e.preventDefault()}>
              <Grid container spacing={2}>
                <Grid item md={6} xs={12} className={classes.gridmb}>
                  <TextField
                    label="Nombre"
                    variant="outlined"
                    fullWidth
                    name="nombre"
                    value={usuario.nombre}
                    onChange={handleChange}
                  />
                </Grid>
                <Grid item md={6} xs={12} className={classes.gridmb}>
                  <TextField
                    label="Apellidos"
                    variant="outlined"
                    fullWidth
                    name="apellidos"
                    value={usuario.apellidos}
                    onChange={handleChange}
                  />
                </Grid>
                <Grid item md={12} xs={12} className={classes.gridmb}>
                  <TextField
                    label="Email"
                    variant="outlined"
                    type="email"
                    fullWidth
                    name="email"
                    value={usuario.email}
                    onChange={handleChange}
                  />
                </Grid>
                <Grid item md={12} xs={12} className={classes.gridmb}>
                  <TextField
                    label="Password"
                    variant="outlined"
                    type="password"
                    fullWidth
                    name="password"
                    value={usuario.password}
                    onChange={handleChange}
                  />
                </Grid>
                <Grid item md={12} xs={12} className={classes.gridmb}>
                  <Button
                    variant="contained"
                    fullWidth
                    color="primary"
                    onClick={guardarUsuario}
                    type="submit"
                  >
                    Registrar
                  </Button>
                </Grid>
              </Grid>
              <Link className={classes.link} to="/" variant="body1">
                ¿Ta tienes una cuenta?,Logueate
              </Link>
            </form>
          </Card>
        </Grid>
      </Grid>
    </Container>
  );
};

export default RegistrarUsuario;
