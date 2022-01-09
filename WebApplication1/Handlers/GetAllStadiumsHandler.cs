using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.ModelsDTO.Stadium;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Queries;

namespace WebApplication1.Handlers
{
    public class GetAllStadiumsHandler : IRequestHandler<GetAllStadiumsQuery, List<StadiumDTO>>
    {
        private readonly IStadiumRepository _stadium;

        public GetAllStadiumsHandler(IStadiumRepository stadium)
        {
            _stadium = stadium;
        }

        public async Task<List<StadiumDTO>> Handle(GetAllStadiumsQuery request, CancellationToken cancellationToken)
        {
            var stadiums = await _stadium.GetStadiums();
            return stadiums;
        }
    }
}
