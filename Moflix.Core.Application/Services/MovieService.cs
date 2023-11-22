using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moflix.Core.Application.DTOs.Account;
using Moflix.Core.Application.Helpers;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Application.Interfaces.Services;
using Moflix.Core.Application.ViewModels.Movies;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Services
{
    public class MovieService : GenericService<SaveMoviesViewModel, MoviesViewModel, Movies>, IMoviesService
    {
        private readonly IMoviesRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;

        public MovieService(IMoviesRepository productRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public override async Task<SaveMoviesViewModel> Add(SaveMoviesViewModel vm)
        {
            vm.UserId = userViewModel != null ? userViewModel.Id : vm.UserId;
            return await base.Add(vm);
        }

        public override async Task Update(SaveMoviesViewModel vm, int id)
        {
            vm.UserId = userViewModel != null ? userViewModel.Id : vm.UserId;
            await base.Update(vm, id);
        }

        public async Task<List<MoviesViewModel>> GetAllViewModelWithInclude()
        {
            var productList = await _productRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            if (userViewModel != null)
            {
                productList = productList.Where(movie => movie.UserId == userViewModel.Id).ToList();
            }

            return productList.Select(movie => new MoviesViewModel
            {
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                Id = movie.Id,
                Director = movie.Director,
                Cover = movie.Cover,
                CategoryName = movie.Category.Name,
                CategoryId = movie.Category.Id
            }).ToList();
        }

        public async Task<List<MoviesViewModel>> GetAllViewModelWithFilters(FilterMovieViewModel filters)
        {
            var productList = await _productRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            if (userViewModel != null)
            {
                productList = productList.Where(product => product.UserId == userViewModel.Id).ToList();
            }

            var listViewModels = productList.Select(movie => new MoviesViewModel
            {
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                Id = movie.Id,
                Director = movie.Director,
                Cover = movie.Cover,
                CategoryName = movie.Category.Name,
                CategoryId = movie.Category.Id
            }).ToList();

            if (filters.CategoryId != null)
            {
                listViewModels = listViewModels.Where(product => product.CategoryId == filters.CategoryId.Value).ToList();
            }

            return listViewModels;
        }
    }
}