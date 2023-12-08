import { useState, useEffect } from 'react'
import { useParams } from 'react-router'
import { useNavigate } from 'react-router-dom'
import axios from 'axios'
import Icon from '../../assets/icons/page.png'

import './index.scss'
import { ENDPOINTS } from '../../services/api'
import { useForm } from '../../hook'

const initialStateMovie = {
  id: 0,
  title: "",
  year: 0,
  director: "",
  synopsis: "",
  src: "",
  cover: "",
  actors: "",
  categoryName: "",
  categoryId: 0,
  categoryWithoutProduct: {
    id: 0,
    name: "",
    description: "",
    productsQuantity: 0,
  },
  category: {
    id: 0,
    name: "",
    description: "",
    products: [""],
    productsQuantity: 0,
  },
}


function index({ type }) {
  const navigate = useNavigate()
  const { id } = useParams()

  const { formState, onInputChange } = useForm(initialStateMovie)

  const [movie, setMovie] = useState(initialStateMovie)

  const typeTitle = type === 'create' ? 'Crear Trailer' : 'Editar trailer';

  useEffect(() => {
    if (type === 'create') return
    axios
      .get(ENDPOINTS.TRAILER.GET.BY_ID(id))
      .then(res => {
        const movie = res.data
        setVideo({ ...movie, actores: movie.actores.join(',') })
      })
  }, [])

  const handleSubmit = async (e) => {
    e.preventDefault()

    if (type === 'create') {
      await axios.post(ENDPOINTS.MOVIES.POST, movie)
      return navigate('/admin')

    }

    await axios.put(ENDPOINTS.MOVIES.PUT.UPDATE(id), movie)
    navigate('/admin')

  }

  const handleChange = e => {
    setMovie({
      ...movie,
      [e.target.name]: e.target.value
    })
  }

  const handleChangeActores = e => {
    const value = e.target.value.split(',')
    setMovie({
      ...movie,
      actores: value
    })
  }

  const handleChangeAño = e => {
    const reg = new RegExp('^[0-9]+$')
    if (reg.exec(e.target.value) || e.target.value == ' ') {
      setMovie({
        ...video,
        año: e.target.value
      })
    }
  }

  return (
    <div className='AdminForm'>
      <img src={Icon} alt='' className='icon-create' />
      <h1>{typeTitle}</h1>
      <form onSubmit={handleSubmit}>
        <div className='row1'>
          <div className='titulo'>
            <label htmlFor='titulo'>
              Titulo
              <input
                type='text'
                name='titulo'
                placeholder=' Ej: La cucaracha'
                id='titulo'
                onChange={onInputChange}
                value={formState.title}
                required
              />
            </label>
          </div>

          <div className='actores'>
            <label htmlFor='actores'>
              Actores
              <input
                type='text'
                name='actores'
                id='actores'
                placeholder='Ej: Juan, Pedro, Juan'
                onChange={onInputChange}
                value={formState.actores}
                required
              />
            </label>
          </div>
          <div className='año'>
            <label htmlFor='año'>
              Año
              <input
                type='text'
                name='año'
                id='año'
                placeholder='Ej: 2019'
                onChange={onInputChange}
                value={formState.año}
                required
              />
            </label>
          </div>
        </div>
        <div className='row2'>
          <div className='director'>
            <label htmlFor='director'>
              Director
              <input
                type='text'
                name='director'
                id='director'
                placeholder='Ej: Juan'
                onChange={onInputChange}
                value={formState.director}
                required
              />
            </label>
          </div>

          <div className='src'>
            <label htmlFor='src'>
              Url del trailer
              <input
                type='text'
                name='src'
                id='src'
                placeholder='Ej: https://www.youtube.com/embed/dQw4w9WgXcQ'
                onChange={onInputChange}
                value={formState.src}
                required
              />
            </label>
          </div>
          <div className='portada'>
            <label htmlFor='portada'>
              Url de la portada
              <input
                type='text'
                name='portada'
                id='portada'
                placeholder='Ej: https://i.imgur.com/pLbxazs.jpg'
                onChange={onInputChange}
                value={formState.portada}
                required
              />
            </label>
          </div>
        </div>
        <div className='row3'>
          <div className='reseña'>
            <label htmlFor='reseña'>
              Reseña
              <textarea
                type='text'
                name='reseña'
                id='reseña'
                placeholder='Ej: La cucaracha es una pelicula de terror'
                onChange={onInputChange}
                value={formState.reseña}
                required
              />
            </label>
          </div>
        </div>
        <div className='buttonContainer'>
          <button type='submit'>Submit</button>
        </div>
      </form>
    </div>
  )
}

export default index
