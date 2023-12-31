import React, { createContext, useReducer } from "react";

const User = createContext();
const useContext = () => React.useContext(User);

function userReducer(state, action) {
  switch (action.type) {

    case 'login': {
      state.token = action.payload;
      return { ...state, token: state.token }
    }

    case 'register': {
      state.token = action.payload;
      return { ...state, token: state.token }
    }

    case 'logout': {
      state.token = "";
      return { ...state, token: state.token }
    }

    case 'update': {
      state.token = action.payload;
      return { ...state, token: state.token }
    }
    case 'delete': {
      state.token = ""
      return { ...state, token: state.token }
    }
    case 'setAuth': {
      state.auth = action.payload;
      return { ...state, auth: state.auth }
    }
    default: {
      console.log(`Unhandled action type: ${action.type}`)
    }
  }
}

const Provider = ({ children }) => {
  let token = localStorage.getItem("token") ? localStorage.getItem("token") : "";
  const [state, dispatch] = useReducer(userReducer, { token, auth: false });
  const values = { state, dispatch };

  return (
    <User.Provider value={values}>
      {children}
    </User.Provider>
  );
};

export { Provider, useContext };
