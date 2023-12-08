import Movie from '../Movie'
import './index.scss'

function ListOfMovies ({ movies }) {
  if (movies?.length === 0) {
    return (
      <div className='trailers-list'>
        <h1>No hay trailers</h1>
      </div>
    )
  }

  return (
    <div className='trailers-list'>
      {movies?.map(movie => (
        <Movie key={movie.id} {...movie}/>
      ))}
    </div>
  )
}




export default ListOfMovies
