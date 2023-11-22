using AutoMapper;
using Moflix.Core.Application.DTOs.Account;
using Moflix.Core.Application.Features.Categories.Commands.CreateCategory;
using Moflix.Core.Application.Features.Categories.Commands.UpdateCategory;
using Moflix.Core.Application.Features.Moviesf.Commands.CreateProduct;
using Moflix.Core.Application.Features.Moviesf.Commands.UpdateProduct;
using Moflix.Core.Application.Features.Moviesf.Queries.GetAllProducts;
using Moflix.Core.Application.ViewModels.Categories;
using Moflix.Core.Application.ViewModels.Movies;
using Moflix.Core.Application.ViewModels.Users;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region MoveieProfile

            CreateMap<Movies, MoviesViewModel>()
                .ForMember(x => x.CategoryName, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Movies, SaveMoviesViewModel>()
            .ForMember(x => x.File, opt => opt.Ignore())
            .ForMember(x => x.Categories, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
            .ForMember(x => x.Category, opt => opt.Ignore());

            #endregion MoveieProfile

            #region CategoryProfile

            CreateMap<Category, CategoryViewModel>()
            .ForMember(x => x.ProductsQuantity, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Category, CategoryWithoutProductsViewModel>()
               .ForMember(x => x.ProductsQuantity, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.Created, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.Movies, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Category, SaveCategoryViewModel>()
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
            .ForMember(x => x.Movies, opt => opt.Ignore());

            #endregion CategoryProfile

            #region UserProfile

            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
            .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUsersViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            #endregion UserProfile

            #region CQRS
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>()
              .ReverseMap();

            CreateMap<CreateMovieCommand, Movies>()
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateProductCommand, Movies>()

                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProductUpdateResponse, Movies>()
              .ForMember(x => x.Category, opt => opt.Ignore())
              .ForMember(x => x.Created, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ReverseMap();

            CreateMap<CreateCategoryCommand, Category>()
            .ForMember(x => x.Movies, opt => opt.Ignore())
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<UpdateCategoryCommand, Category>()

                .ForMember(x => x.Movies, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CategoryUpdateResponse, Category>()
             .ForMember(x => x.Movies, opt => opt.Ignore())
             .ForMember(x => x.Created, opt => opt.Ignore())
             .ForMember(x => x.CreatedBy, opt => opt.Ignore())
             .ForMember(x => x.LastModified, opt => opt.Ignore())
             .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
             .ReverseMap();

            #endregion
        }
    }
}