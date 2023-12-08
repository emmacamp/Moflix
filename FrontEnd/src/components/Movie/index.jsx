import React from 'react'
import { Link } from 'react-router-dom'
import './index.scss'
import play from '../../assets/icons/play.svg'

function Movie(props) {
  const { id, title, cover, synopsis } = props;

  return (
    <div className='videoWrapper'>
      <Link to={`/movie/${id}`}>
        <img className='videoWrapper__video' alt={`${title}: ${synopsis}`} src={cover} title={synopsis} />
        <div className='videoWrapper__wrapper'>
          <img src={play} alt='Play' />
          <h2>{titulo}</h2>
        </div>
      </Link>
    </div>
  )
}

export default Movie
