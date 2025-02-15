using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _ctx;

        public UpdateCategoryCommandHandler(MovieContext ctx)
        {
            _ctx = ctx;
        }

        public async void Handle(UpdateCategoryCommand command)
        {
            var category = await _ctx.Categories.FindAsync(command.Id);
            if(category != null)
            {
                category.Name = command.Name;
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
