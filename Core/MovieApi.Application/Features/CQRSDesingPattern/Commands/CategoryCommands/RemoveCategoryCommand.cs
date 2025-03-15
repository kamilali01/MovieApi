using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public RemoveCategoryCommand(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
