import React,{ useEffect, useState} from "react";
import { ThemeProvider } from "@material-ui/core";
import theme from "./theme/theme";
import AuthPage from "./componentes/login/AuthPage";
import { getUsuario } from "./actions/UsuarioActions";
import { useStateValue } from "./contexto/store";
function App() {
  const [{sesionUsuario}, dispatch] = useStateValue();
  const [servidorRespuesta, setServidorRespuesta] = useState(false);
  useEffect(() => {
    if(!servidorRespuesta){
      getUsuario(dispatch).then(response =>{
        setServidorRespuesta(true);
      })
    }
  }, [servidorRespuesta]);
  return (
    <ThemeProvider theme={theme}>
      <AuthPage></AuthPage>
    </ThemeProvider>
  );
}

export default App;
