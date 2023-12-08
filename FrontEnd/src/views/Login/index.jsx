import axios from 'axios'

import { useNavigate } from 'react-router-dom'
import { useContext } from '../../Context'
import { useForm } from '../../hook'
import { ENDPOINTS } from '../../services/api'

import Swal from 'sweetalert2'
import './index.scss'

export const Login = () => {
  const navigate = useNavigate()
  const { dispatch } = useContext()

  const {formState, onInputChange } = useForm({
    email: "",
    password: ""
  })

  const handleSubmit = (e) => {
    e.preventDefault()
    if (!formState.email || !formState.password) {
      Swal.fire({
        title: 'Campos incompletos',
        text: 'Todos los campos son obligatorios',
        icon: 'error'
      })
      return
    }

    console.log(formState);
    auth()


  }


  const auth = async () => {
    await axios
      .post(ENDPOINTS.ACCOUNT.POST.AUTHENTICATE, formState)
      .then((res) => {
        window.localStorage.setItem('token', res.data.body.token)
        dispatch({ type: 'login', payload: res.data.body.token })
        navigate('/admin')
      })
      .catch((error) => {
        console.log(error)
        Swal.fire({
          title: 'Error de autenticación',
          text: String(error.message).includes('Network') ? 'Error de conexión' : error.message,
          icon: 'error'
        })
      })
  }

  return (
    <div className='Form' id="login">
      <form onSubmit={handleSubmit} className='form' autoComplete='off'>
        <img src='/src/assets/icons/user.png' alt='' />
        <h1>Iniciar Sessión</h1>
        <div className='input-container'>
          <input
            required
            type='text'
            placeholder='Email'
            name='email'
            autoComplete='off'
            value={formState.email}
            onChange={onInputChange}
          />
          <i className='zmdi zmdi-account zmdi-hc-lg' />
        </div>

        <div className='input-container'>
          <input
            required
            type='password'
            placeholder='Password'
            autoComplete='off'
            name='password'
            value={formState.password}
            onChange={onInputChange}
          />
          <i className='zmdi zmdi-lock zmdi-hc-lg' />
        </div>
        <button type='submit'>
          Submit
        </button>
      </form>
    </div>
  )
}

export default Login
