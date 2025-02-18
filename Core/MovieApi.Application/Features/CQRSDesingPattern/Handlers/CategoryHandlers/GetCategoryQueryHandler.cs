﻿using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _ctx;

        public GetCategoryQueryHandler(MovieContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = _ctx.Categories.ToListAsync();
            return values.Result.Select(x => new GetCategoryQueryResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
