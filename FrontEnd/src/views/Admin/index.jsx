import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import axios from 'axios'
import useFilter from './../../hook/useFilter'
import Video from '../../components/AdminVideo'
import Swal from 'sweetalert2'
import './index.scss'

function index() {

	const [videos, setVideos] = useState([])
	const [videosFilted, setVideosFilted] = useState([])

	const handleDelete = e => {
		Swal.fire({
			title: 'Seguro que quieres borrar este trailer?',
			text: 'No podras recuperarlo!',
			icon: 'warning',
			showCancelButton: true,
			confirmButtonColor: '#3085d6',
			cancelButtonColor: '#d33',
			confirmButtonText: 'Yes, delete it!'
		}).then((result) => {
			if (result.isConfirmed) {
				Swal.fire(
					'Deleted!',
					'Your file has been deleted.',
					'success'
				)
				const id = e.target.id
				axios.delete(`http://localhost:4000/trailer/delete/${id}`).then(() => {
					setVideosFilted(videos.filter(video => video._id !== id))
				})
			}
		})
	}
	useEffect(() => {
		axios('http://localhost:4000/trailer').then(res => {
			setVideos(res.data.body)
			setVideosFilted(res.data.body)
		})
	}, [])

	return (
		<div className='admin'>
			<div className='admin__header'>
				<h3>Moflix Admin Server</h3>
			</div>
			<div className='admin__actions'>
				<Link to='/admin/create'>
					<button>New Trailer</button>
				</Link>
				<input
					type='text'
					id='search'
					placeholder='search'
					onChange={e => setVideosFilted(useFilter(videos, e.target.value))}
				/>
			</div>
			<div className='admin__videos'>
				<table>
					<thead>
						<tr>
							<th>Portada</th>
							<th>Titulo</th>
							<th>Actores</th>
							<th>Reseña</th>
							<th>Año</th>
							<th>Acciones</th>
						</tr>
					</thead>
					<tbody>
						{
							videosFilted.length > 0
								? videosFilted.map((video, i) => (
									<Video
										titulo={video.titulo}
										actores={video.actores}
										año={video.año}
										reseña={video.reseña}
										portada={video.portada}
										id={video._id}
										key={video._id ? video._id : i}
										handleDelete={handleDelete}
										{...video}
									/>
								))
								: <span />
						}
					</tbody>
				</table>
				{
					videosFilted.length === 0 && <h2>No hay trailers que coincidan con su busqueda</h2>
				}
			</div>
		</div>
	)
}

export default index
