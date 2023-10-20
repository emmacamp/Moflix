import Video from '../Video'
import './index.scss'

function index ({ trailers }) {
  if (trailers?.length === 0) {
    return (
      <div className='trailers-list'>
        <h1>No hay trailers</h1>
      </div>
    )
  }

  return (
    <div className='trailers-list'>
      {trailers?.map(video => (
        <Video
          titulo={video.titulo}
          actores={video.actores}
          año={video.año}
          src={video.src}
          id={video._id}
          key={video._id}
          portada={video.portada}
          {...video}
        />
      ))}
    </div>
  )
}

export default index
