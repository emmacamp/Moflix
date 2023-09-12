const API_URL = 'http://localhost:5000';

export const ENDPOINTS = {
    USER: {
        LOGIN: `${API_URL}/auth/login`,
        REGISTER: `${API_URL}/auth/register`,
        TRAILERS: `${API_URL}/trailers`,
        TRAILER: `${API_URL}/trailers/`,
    },
    TRAILERS: {
        GET_TRAILERS: `${API_URL}/trailers`,
        CREATE_TRAILER: `${API_URL}/trailer`,
        GET_TRAILER: `${API_URL}/trailers/`,
        UPDATE_TRAILER: `${API_URL}/trailers/`,
        DELETE_TRAILER: `${API_URL}/trailers/`,
    }
}
