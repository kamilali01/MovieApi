using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _ctx;

        public CreateCategoryCommandHandler(MovieContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            _ctx.Categories.Add(new Category
            {
                Name = command.Name
            });
            await _ctx.SaveChangesAsync();
        }
    }
}
