using MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesingPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _ctx;

        public GetMovieByIdQueryHandler(MovieContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<GetMovieByIdQueryResult> Handler(GetMovieByIdQuery query)
        {
            var value = await _ctx.Movies.FindAsync(query.Id);
            return new GetMovieByIdQueryResult
            {
                Id = value.Id,
                Title = value.Title,
                CoverImageUrl = value.CoverImageUrl,
                Description = value.Description,
                ReleaseDate = value.ReleaseDate,
                Rating = value.Rating,
                Status = value.Status,
                Duration = value.Duration,
                CreatedYear = value.CreatedYear


            };
        }
    }
}
