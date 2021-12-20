import sesionUsaurioReducer from "./sesionUsuarioReducer"


export const mainReducer = ( {sesionUsuario}, action) => {
    return {
        sesionUsuario : sesionUsaurioReducer(sesionUsuario,action)
    }
}