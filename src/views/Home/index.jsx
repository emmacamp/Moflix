import axios from "axios";
import { useEffect, useState } from "react";
import ListOfVideos from '../../components/ListOfVideos';
import "./index.scss";
import { ENDPOINTS } from "../../services/api";

function index() {
	const [videos, setVideos] = useState([]);
	useEffect(() => {
		// ReactGA.pageview(window.location.pathname + window.location.search);
		axios(ENDPOINTS.TRAILERS.GET_TRAILERS).then(res => {
			setVideos(res.data.body);
		});

	}, []);

	return (
		<div className='Home'>
			<h1>Home</h1>
			<ListOfVideos videos={videos} />
		</div>
	);
}

export default index;
