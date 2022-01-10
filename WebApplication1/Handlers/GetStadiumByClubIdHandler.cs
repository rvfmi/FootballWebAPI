using Infrastructure.Interfaces;
using Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Queries;

namespace WebApplication1.Handlers
{
    public class GetStadiumByClubIdHandler : IRequestHandler<GetStadiumByClubIdQuery, Stadium>
    {
        private readonly IStadiumRepository _repostitory;

        public GetStadiumByClubIdHandler(IStadiumRepository repostitory)
        {
            _repostitory = repostitory;
        }

        public Task<Stadium> Handle(GetStadiumByClubIdQuery request, CancellationToken cancellationToken)
        {
            var stadium = _repostitory.GetStadiumByClubId(request.Id);
            return stadium == null ? null : stadium;
        }
    }
}
