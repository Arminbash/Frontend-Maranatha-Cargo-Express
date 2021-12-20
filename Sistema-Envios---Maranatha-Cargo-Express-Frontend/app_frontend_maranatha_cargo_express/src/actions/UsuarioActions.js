import HttpClient from '../Servicios/HttpClient';
import axios from 'axios';

//Cancelar token
const instancia = axios.create();
instancia.CancelToken = axios.CancelToken;
instancia.isCancel = axios.isCancel;

export const loginUsuario = (usuario,dispatch) => {
    return new Promise((resolve, eject) => {
        instancia.post('/api/Usuario/login', usuario).then(response => {
            dispatch ({
                type: "INICIAR_SESION",
                sesion: response.data,
                autenticado: true
            })
            resolve(response);
        })
        .catch((error) => {
            resolve(error.response);
        })
    });
}


export  const getUsuario = ( dispatch ) => {
    return new Promise((resolve,eject) => {
        HttpClient.get("/api/Usuario").then(response => {
            dispatch ({
                type: "INICIAR_SESION",
                sesion: response.data,
                autenticado: true
            })
            resolve(response);
        })
        .catch(error =>{
            resolve(error.response);
        })
    });
}
