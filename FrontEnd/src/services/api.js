const API_URL = 'http://localhost:5036/api'
const API_URL_V = 'http://localhost:5036/api/v1'



export const ENDPOINTS = {
  ACCOUNT: {
    GET: {
      CONFIRM_EMAIL: `${API_URL}/Account/confirm-email`,
    },
    POST: {
      AUTHENTICATE: `${API_URL}/Account/Authenticate`,
      REGISTER: `${API_URL}/Account/register`,
      FORGOT_PASSWORD: ({ userId, token }) => `${API_URL}/Account/forgot-password?userId=${userId}&token=${token}`,
      RESET_PASSWORD: `${API_URL}/Account/reset-password`,
    }
  },
  CATEGORY: {
    GET: {
      ALL: `${API_URL}/Category`,
      BY_ID: (id) => `${API_URL}/category/${id}`,
    },
    POST: {
      CREATE: `${API_URL}/category`,
    },
    PUT: {
      UPDATE: (id) => `${API_URL}/category/${id}`,
    },
    DELETE: {
      DELETE: (id) => `${API_URL}/category/${id}`,
    }
  },
  MOVIES: {
    GET: {
      ALL: `${API_URL_V}/Movies`,
      BY_ID: (id) => `${API_URL_V}/Movies/${id}`,
    },
    POST: {
      CREATE: `${API_URL_V}/Movies`,
    },
    PUT: {
      UPDATE: (id) => `${API_URL_V}/Movies/${id}`,
    },
    DELETE: {
      DELETE: (id) => `${API_URL_V}/Movies/${id}`,
    },
  },
}
