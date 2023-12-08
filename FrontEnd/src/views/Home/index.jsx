import axios from "axios";
import { useEffect, useState } from "react";
import ListOfMovies from '../../components/ListOfMovies';
import { ENDPOINTS } from "../../services/api";
import cinemaImg from '../../assets/home_cinema.svg';
import "./index.scss";


function index() {
	const [videos, setVideos] = useState([]);
	useEffect(() => {
		axios(ENDPOINTS.MOVIES.GET.ALL).then(res => {
			setVideos(res.data);
		});

	}, []);

	return (
		<div className='Home'>
			{/* <h1>Home</h1> */}
			{
				videos.length > 0
					? <ListOfMovies movies={videos} />
					: <div className="container-img-home">
						<img src={cinemaImg} alt="cinema img" />
						<h1>No hay trailers</h1>
					</div>
			}
		</div>
	);
}

export default index;
