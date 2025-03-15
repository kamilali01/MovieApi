using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _ctx;

        public GetMovieQueryHandler(MovieContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var values = _ctx.Movies.ToListAsync();
            return values.Result.Select(x => new GetMovieQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                CreatedYear = x.CreatedYear,
                Status = x.Status
            }).ToList();
        }
    }
}
