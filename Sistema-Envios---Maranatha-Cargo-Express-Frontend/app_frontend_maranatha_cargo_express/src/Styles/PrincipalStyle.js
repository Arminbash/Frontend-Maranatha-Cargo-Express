import { makeStyles, createTheme } from "@material-ui/core";

const theme = createTheme();

const principalStyle = makeStyles({
  root:{
      display:'flex'
  },
  toolbar: theme.mixins.toolbar,
  content :{
      flexGrow : 1,
      backgroundColor :theme.palette.background.default,
      padding: theme.spacing(3),
  },
  drawer:{
      width: 240,
      flexShrink:0
  },
  drawerPaper:{
    width: 240
},
avatar: {
    display: 'flex',
    '& > *': {
      margin: theme.spacing(1),
    },
  },
  link:{
    color:'#062237',
    marginLeft:15,
    marginTop: 20,
    fontSize: 15
}

});

export default principalStyle;