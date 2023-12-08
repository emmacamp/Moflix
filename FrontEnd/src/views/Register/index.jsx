import axios from 'axios'
import { useNavigate } from 'react-router-dom'
import { useState } from 'react'
import './index.scss'
import { useContext } from '../../Context'
import Swal from 'sweetalert2'
import { ENDPOINTS } from '../../services/api'
import { useForm } from '../../hook'

function Register() {
  const { dispatch } = useContext()
  const navigate = useNavigate()

  const { formState, onInputChange } = useForm({
    firstName: "",
    lastName: "",
    email: "",
    userName: "",
    password: "",
    confirmPassword: "",
    phone: ""
  })




  const handleSubmit = (e) => {
    e.preventDefault()
    if (!formState.email || !formState.password, !formState.firstName, !formState.lastName, !formState.userName, !formState.confirmPassword, !formState.phone) {
      return Swal.fire({
        title: 'Campos incompletos',
        text: 'Todos los campos son obligatorios',
        icon: 'error'
      })
    }

    console.log(formState);
    // register()
  }

  const register = async () => {
    axios
      .post(ENDPOINTS.ACCOUNT.POST.REGISTER, formState)
      .then((res) => {
        Swal.fire({
          title: 'Usuario creado',
          text: res.data.message,
          icon: 'success'
        })

        dispatch({ type: 'register', payload: res.data })
        navigate('/login')

      })
      .catch((error) => {
        console.log(error)
        Swal.fire({
          title: 'Error',
          text: error.message,
          icon: 'error'
        })
      })
  }

  return (
    <div className='Form' id="register">
      <form onSubmit={handleSubmit} className='form' autoComplete='off'>
        <img src='/src/assets/icons/user.png' alt='' />
        <h1>Register</h1>
        <div className='input-container'>
          <input
            required
            type='text'
            placeholder='First Name'
            name='firstName'
            autoComplete='off'
            value={formState.firstName}
            onChange={onInputChange}
          />
        </div>

        <div className='input-container'>
          <input
            required
            type='text'
            placeholder='Last Name'
            name='lastName'
            autoComplete='off'
            value={formState.lastName}
            onChange={onInputChange}
          />
        </div>

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
        </div>

        <div className='input-container'>
          <input
            required
            type='text'
            placeholder='Username'
            name='userName'
            autoComplete='off'
            value={formState.userName}
            onChange={onInputChange}
          />
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
        </div>

        <div className='input-container'>
          <input
            required
            type='password'
            placeholder='Confirm Password'
            autoComplete='off'
            name='confirmPassword'
            value={formState.confirmPassword}
            onChange={onInputChange}
          />
        </div>

        <div className='input-container'>
          <input
            required
            type='text'
            placeholder='Phone'
            name='phone'
            autoComplete='off'
            value={formState.phone}
            onChange={onInputChange}
          />
        </div>

        <button onClick={handleSubmit} type='submit'>
          Submit
        </button>
      </form>
    </div>
  )
}

export default Register
