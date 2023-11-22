import React from 'react'
import { Navigate, Outlet } from 'react-router-dom'
import { useContext } from '../../Context'

const useAuth = () => {
  const { state } = useContext()
  return state.auth
}

const ProtectedRoutes = () => {
  // const auth = true
  const auth = useAuth()
  return auth ? <Outlet /> : <Navigate to='/login' />
}

export default ProtectedRoutes
