import {
  Container,
  Grid,
  Card,
  Typography,
  Icon,
  Avatar,
  TextField,
  Button
} from "@material-ui/core";
import useStyles from "../../Styles/useStyles";
import { Link,useNavigate} from "react-router-dom";
import { loginUsuario } from "../../actions/UsuarioActions";
import { useFormik } from "formik";
import * as Yup from "yup";
import Alert from "@material-ui/lab/Alert";
import React from "react";
import { useStateValue } from "../../contexto/store";
const loginSchema = Yup.object().shape({
  email: Yup.string()
    .email("Wrong email format")
    .min(3, "Minimum 3 symbols")
    .max(50, "Maximum 50 symbols")
    .required("Email is required"),
  password: Yup.string()
    .min(3, "Minimum 3 symbols")
    .max(50, "Maximum 50 symbols")
    .required("Password is required")
});
const initialValues = {
  email: "",
  password: ""
};

const Login = () => {
  const classes = useStyles();
  const [{sesionUsuario}, dispatch] = useStateValue();
  const history = useNavigate();
  const formik = useFormik({
    initialValues,
    validationSchema: loginSchema,
    onSubmit: (values, { setStatus, setSubmitting }) => {
      setTimeout(() => {
        loginUsuario(values,dispatch)
          .then(response => {
            if(response.status === 200){
              console.log("login Exitoso", response);
              window.localStorage.setItem('token_seguridad', response.data.token);
              history('/Principal');
            }else
            {
              setSubmitting(false);
              setStatus("Contraseña o Correo incorrecto");
            }
          })
          .catch(() => {
            setSubmitting(false);
            setStatus("Contraseña o Correo incorrecto");
          });
      }, 3);
    }
  });

  return (
    <Container className={classes.containermt}>
      <Grid container justifyContent="center">
        <Grid item lg={5} md={6}>
          <Card className={classes.card} align="center">
            <Avatar className={classes.avatar}>
              <Icon className={classes.icon}>account_circle</Icon>
            </Avatar>
            <Typography variant="h5" color="primary">
              Ingrese su Usuario
            </Typography>
            {formik.status ? (
              <Alert  severity="error">
                {formik.status}
              </Alert>
            ) : (
              <div></div>
            )}
            <form
              className={classes.form}
              onSubmit={formik.handleSubmit}
              noValidate
            >
              <Grid container spacing={2}>
                <Grid className={classes.gridmb} item xs={12}>
                  <TextField
                    name="email"
                    label="Email"
                    variant="outlined"
                    fullWidth
                    type="email"
                    value={formik.values.email}
                    onChange={formik.handleChange}
                    onBlur={formik.handleBlur}
                    error={formik.touched.email && Boolean(formik.errors.email)}
                    helperText={formik.touched.email && formik.errors.email}
                  ></TextField>
                </Grid>
              </Grid>
              <Grid container spacing={2}>
                <Grid className={classes.gridmb} item xs={12}>
                  <TextField
                    name="password"
                    label="Password"
                    variant="outlined"
                    fullWidth
                    type="password"
                    value={formik.values.password}
                    onChange={formik.handleChange}
                    error={
                      formik.touched.password && Boolean(formik.errors.password)
                    }
                    helperText={
                      formik.touched.password && formik.errors.password
                    }
                    onBlur={formik.handleBlur}
                  ></TextField>
                </Grid>
              </Grid>
              <Grid container spacing={2}>
                <Grid className={classes.gridmb} item xs={12}>
                  <Button
                    variant="contained"
                    fullWidth
                    color="primary"
                    type="submit"
                    disabled={formik.touched.password && Boolean(formik.errors.password)}
                  >
                    Ingresar
                  </Button>
                </Grid>
              </Grid>
              <Link
                className={classes.link}
                to="/auth/Registrar"
                variant="body1"
              >
                ¿No tienes cuenta?, Registrate
              </Link>
            </form>
          </Card>
        </Grid>
      </Grid>
    </Container>
  );
};

export default Login;
