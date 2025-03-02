using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesingPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieContext _ctx;

        public GetCategoryByIdQueryHandler(MovieContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<GetCategoryByIdQueryResult> Handler(GetCategoryByIdQuery query)
        {
            var value = await _ctx.Categories.FindAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
        }
    }
}
