using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moflix.Core.Application.Features.Categories.Commands.CreateCategory;
using Moflix.Core.Application.Features.Categories.Commands.DeleteCategoryById;
using Moflix.Core.Application.Features.Categories.Commands.UpdateCategory;
using Moflix.Core.Application.Features.Categories.Queries.GetAllCategories;
using Moflix.Core.Application.Features.Categories.Queries.GetCategoryById;
using Moflix.Core.Application.ViewModels.Categories;

namespace Moflix.Controllers.V1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "SuperAdmin")]
    public class CategoryController : BaseAPIController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllCategoriesQuery()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveCategoryViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetCategoryByIdQuery { Id = id }));
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
        public async Task<IActionResult> Post(CreateCategoryCommand command)
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveCategoryViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateCategoryCommand command)
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
                await Mediator.Send(new DeleteCategoryByIdCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
