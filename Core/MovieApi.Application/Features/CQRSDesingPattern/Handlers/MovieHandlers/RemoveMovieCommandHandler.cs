using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _ctx;

        public RemoveMovieCommandHandler(MovieContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Handle(RemoveMovieCommand command)
        {
            var movie = await _ctx.Movies.FindAsync(command.Id);
            if (movie != null)
            {
                _ctx.Movies.Remove(movie);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
