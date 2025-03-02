using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _ctx;

        public RemoveCategoryCommandHandler(MovieContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _ctx.Categories.FindAsync(command.Id);
            if (category != null)
            {
                _ctx.Categories.Remove(category);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
