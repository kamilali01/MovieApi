using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _getCategoryQueryHandler.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Category successfully added");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Category successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Category successfully updated");
        }
    }
}
