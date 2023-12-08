import './index.scss'
import { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import configIcon from '../../assets/config.svg'
import Swal from 'sweetalert2'
// import withReactContent from 'sweetalert2-react-content'

function index() {
  //   const MySwal = withReactContent(Swal)
  const [search, setSearch] = useState('')
  const navigate = useNavigate()
  const handleChange = e => {
    setSearch(e.target.value)
  }
  const handleSubmit = e => {
    e.preventDefault()
    if (search.length === 0) {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'No se puede realizar una busqueda vacia!',
        footer: '<a href>¿Necesitas ayuda?</a>',
        confirmButtonColor: '#f14668'
      })
      return
    }
    navigate(`/search/${search}`)
  }

  const onClickDropbtn = () => {
    // e.preventDefault()
    window.document.getElementById('myDropdown').classList.toggle('show')
  }

  // Close the dropdown menu if the user clicks outside of it
  window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
      var dropdowns = document.getElementsByClassName("dropdown-content");
      var i;
      for (i = 0; i < dropdowns.length; i++) {
        var openDropdown = dropdowns[i];
        if (openDropdown.classList.contains('show')) {
          openDropdown.classList.remove('show');
        }
      }
    }
  }


  return (
    <div className='NavbarWrapper'>
      <div className='Navbar'>
        <Link to='/'>
          <div className='Navbar__logo'>
            <span>Moflix</span>
          </div>
        </Link>
        <div className='Navbar__search'>
          <form onSubmit={handleSubmit}>
            <input
              type='search'
              placeholder='Search'
              value={search}
              onChange={handleChange}
            />
            <button>Search</button>
          </form>
        </div>
        <div className='dropdown_img_btn dropdown'>
            <img className='dropbtn' src={configIcon} alt="dropdown button" onClick={onClickDropbtn}/>
        
          <div id="myDropdown" className="dropdown-content show">
            <Link to='/login'>Login</Link>
            <Link to='/register'>Register</Link>
            <Link to='/admin'>Admin Panel</Link>
          </div>
        </div>
      </div>
    </div>
  )
}

export default index
