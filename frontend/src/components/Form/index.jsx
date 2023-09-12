import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import "./index.scss";
import { useContext } from "../../Context";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { ENDPOINTS } from "../../services/api";

/* A function that is being called in the Login.js file. */
function index({ type }) {
  const [form, setForm] = useState({
    name: "",
    password: "",
  });
  const { dispatch } = useContext();
  const typeURL = type === "LOGIN" ? "LOGIN" : "REGISTER";
  const typeTitle = type === "LOGIN" ? "Iniciar Sessión" : "Registrarse";

  let navigate = useNavigate();

  /* Preventing the default action of the form. */
  const handleSubmit = (e) => {
    e.preventDefault();
    if (!form.name || !form.password) {
      Swal.fire({
        title: "Campos incompletos",
        text: "Todos los campos son obligatorios",
        icon: "error",
      });
      return;
    }
    axios
      .post(ENDPOINTS.USER[typeURL], form)
      .then((res) => {
        localStorage.setItem("token", res.data.body.token);
        dispatch({ type: "login", payload: res.data.body.token });
        navigate("/admin");
      })
      .catch((err) => {
        Swal.fire({
          title: "Error",
          text: "Usuario o contraseña incorrectos",
          icon: "error",
        });
      });
  };

  const handleChange = (e) => {
    e.preventDefault();
    setForm({
      ...form,
      [e.target.name]: e.target.value,
    });
  };

  return (
    <div className="Form">
      <form className="form" autoComplete="off">
        <img src="/src/assets/icons/user.png" alt="" />
        <h1>{typeTitle}</h1>
        <div className="input-container">
          <input
            required
            type="text"
            placeholder="Username"
            name="name"
            autoComplete="off"
            value={form.name}
            onChange={handleChange}
          />
          <i className="zmdi zmdi-account zmdi-hc-lg"></i>
        </div>

        <div className="input-container">
          <input
            required
            type="password"
            placeholder="Password"
            autoComplete="off"
            name="password"
            value={form.password}
            onChange={handleChange}
          />{" "}
          <i className="zmdi zmdi-lock zmdi-hc-lg"></i>
        </div>
        <button onClick={handleSubmit} type="submit">
          Submit
        </button>
      </form>
    </div>
  );
}

export default index;