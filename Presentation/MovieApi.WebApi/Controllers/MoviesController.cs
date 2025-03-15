using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieQueryHandler getMovieQueryHandler, GetMovieByIdQueryHandler getMovieByIdQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieQueryHandler = getMovieQueryHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _getMovieQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Movie successfully added");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Movie successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Movie successfully updated");
        }
    }
}
