using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery
    {
        public GetCategoryByIdQuery(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
