import { makeStyles, createTheme } from "@material-ui/core";

const theme = createTheme();

const useStyles = makeStyles({
  containermt: {
    marginTop: 90
  },
  card: {
    padding: 30
  },
  avatar: {
    backgroundColor: "#007CEC",
    width: 80,
    height: 80
  },
  icon: {
    fontSize: 60
  },
  form: {
    marginTop: 50,
    marginBottom: 10
  },
  gridmb: {
    marginBottom: 20
  },
  link: {
    marginTop: 8,
    fontSize: "1.1rem",
    frontFamily: "Roboto",
    lineHeight : 1.5,
    color: theme.palette.primary.main,
    textDecoration : "none"
  },
  appBar: {
   width: `calc(100% -${240}px)`,
   marginLeft: 240
  },
  grow: {
    flexGrow: 0,
    [theme.breakpoints.up('sm')]:{
      flexGrow :1
    }
  },
  linkAppBarLogo: {
    display: "inline-flex",
    alignItems: "center"
  },
  mr: {
      marginRight: 3
  },
  buttonIcon:{
      fontSize:14,
      padding:0
  },
  linkAppBarDesktop:{
      display: "inline-flex",
      alignItems : "center",
      padding:"6px 16px"
  },
  lst:{
    width: 300
  },
  lstItem: {
    padding: 0
  },
  linkAppBarMobile:{
    display : "inline-flex",
    alignItems: "center",
    width :'100%',
    padding : '8px 16px'
  },
  lstItemIcon:{
    minWidth: 35
  },
  sectionDesktop:{
    display : "none",
    [theme.breakpoints.up('md')]:{
      display :"flex"
    }
  },
    sectionMobile: {
      display : "flex",
      flexGrow : 1,
      [theme.breakpoints.up('md')]:{
        display :"none"
      }
    }
});

export default useStyles;
