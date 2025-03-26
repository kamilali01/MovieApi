﻿using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries
{
    public class GetCastByIdQuery:IRequest<GetCastByIdQueryResult>
    {
        public GetCastByIdQuery(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
