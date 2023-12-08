import { useParams } from "react-router";
import axios from "axios";
import { useEffect, useState } from "react";
import useFilter from "./../../hook/useFilter";
import ListOfMovies from "../../components/ListOfMovies";
import "./index.scss";
import { ENDPOINTS } from "../../services/api";
import NotSearchImage from "../../assets/horror_movie.svg";

function index() {
	const { search } = useParams();
	const [results, setResults] = useState([]);

	useEffect(() => {
		axios.get(ENDPOINTS.MOVIES.GET.ALL).then(data => {
			setResults(useFilter(data.data.body, search));
		});
	}, [search]);


	return (
		<div className='Search'>
			<h1>Busqueda: {search}</h1>
			{results.length > 0 ? (
				<ListOfMovies movies={results} />
			) : (
					<div className="container-img-search">
						<img src={NotSearchImage} alt="not-search-img img" />
						<h1>No hay trailers</h1>
					</div>
			)}
		</div>
	);
}

export default index;
