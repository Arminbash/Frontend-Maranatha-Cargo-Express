export const initialState = {
    usuario : {
        nombreCompleto :"",
        apellido :"",
        email :"",
        userName :"",
        imagen: ""
    },
    autenticado: false
};

const sesionUsaurioReducer = (state = initialState, action) => {
    switch (action.type){
        case "INICIAR_SESION":
            return {
                ...state,
                usuario : action.sesion,
                autenticado : action.autenticado
            };
        case "SALIR_SESION":
            return {
                ...state,
                usuario : action.nuevoUsuario,
                autenticado : action.autenticado
            };
        case "Actualizar_Usaurio":
            return {
                ...state,
                usuario : action.sesion,
                autenticado : action.autenticado
            };
        default : return state;
    }
}

export default sesionUsaurioReducer;