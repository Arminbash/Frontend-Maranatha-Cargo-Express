import {React} from "react";
import {
  Typography,
  AppBar,
  Link,
  Container,
  Icon,
  Toolbar,
  Button,
  IconButton,
} from "@material-ui/core";
import useStyles from "../../Styles/useStyles";

const MenuAppBar = (props) => {
  const classes = useStyles();
  return (
    <AppBar position="fixed" className={classes.appBar}>
      <Container>
        <Toolbar>
          <div className={classes.sectionMobile}>
            <IconButton color="inherit" onClick={() => props.accionOpen()}>
              <Icon fontSize="large" >menu</Icon>
            </IconButton>
          </div>
          <div className={classes.grow}>
            <Link
              color="inherit"
              underline="none"
              className={classes.linkAppBarLogo}
            >
              <Icon className={classes.mr} fontSize="large">
                store
              </Icon>
              <Typography variant="h5">ArminShop</Typography>
            </Link>
          </div>
          <div className={classes.sectionDesktop}>
            <Button color="inherit" className={classes.buttonIcon}>
              <Link
                color="inherit"
                underline="none"
                className={classes.linkAppBarDesktop}
              >
                <Icon className={classes.mr}>person</Icon>
                Login
              </Link>
            </Button>
          </div>
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export default MenuAppBar;
