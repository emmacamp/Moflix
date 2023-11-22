using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moflix.Controllers;
using Moflix.Core.Application.Features.Moviesf.Commands.UpdateProduct;
using Moflix.Core.Application.Features.Moviesf.Queries.GetAllProducts;
using Moflix.Core.Application.Features.Moviesf.Queries.GetProductById;         
using Moflix.Core.Application.Features.Moviesf.Commands.CreateProduct;
using Moflix.Core.Application.Features.Moviesf.Commands.DeleteProductById;
using Moflix.Core.Application.ViewModels.Movies;

namespace Moflix.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "SuperAdmin")]
    public class MoviesController : BaseAPIController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsParameter filters)
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllProductsQuery() { CategoryId = filters.CategoryId }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveMoviesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {   
                return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateMovieCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log or inspect the inner exception for details
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                // Log the exception message
                Console.WriteLine($"Exception Message: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


                [HttpPut("{id}")]
                [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveMoviesViewModel))]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                [ProducesResponseType(StatusCodes.Status500InternalServerError)]
                public async Task<IActionResult> Put(int id, UpdateProductCommand command)
                {
                    try
                    {
                        if (!ModelState.IsValid)
                        {
                            return BadRequest();
                        }
                        if (id != command.Id)
                        {
                            return BadRequest();
                        }

                        return Ok(await Mediator.Send(command));
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                    }
                }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteMovieByIdCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
