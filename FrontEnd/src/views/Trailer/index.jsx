import { useParams } from "react-router";
import { useState, useEffect } from "react";
import axios from "axios";
import "./index.scss";
import { ENDPOINTS } from "../../services/api";

function index() {
  const { id } = useParams();
  const [movie, setMovie] = useState({
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
  });


  useEffect(() => {
    axios.get(ENDPOINTS.MOVIES.GET.BY_ID(id))
      .then((res) => {
        setMovie(res.data);
        console.log(res.data);
      });
  }, []);

  return (
    <div className="trailer">
      <div className="trailer__info">
        <div className="trailer__info__portada">
          <img
            src={movie.cover}
            alt={`Portada de la pelicula ${movie.title}`}
          />
        </div>
        <div className="trailer__info__description">
          <div className="titulo">
            <p>{movie.title}</p>
          </div>
          <div className="info">
            <p>
              Director: <strong>{movie.director}</strong>
            </p>
            <p>
              Actores: <strong>{movie.actors} </strong>
            </p>
            <p>
              Año: <strong>{movie.year} </strong>
            </p>
          </div>
          <p>Reseña: {movie?.reseña}</p>
        </div>
      </div>

      <div className="trailer__video">
        <iframe
          src={
            movie.src
              ? movie.src
              : "https://www.youtube.com/embed/z9ZqsviNASs"
          }
          title="YouTube video player"
          frameBorder="0"
          allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
          allowFullScreen
        ></iframe>
      </div>
    </div>
  );
}

export default index;
