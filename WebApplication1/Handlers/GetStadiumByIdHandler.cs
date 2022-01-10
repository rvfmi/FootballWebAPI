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
    public class GetStadiumByIdHandler : IRequestHandler<GetStadiumByIdQuery, Stadium>
    {
        private readonly IStadiumRepository _repository;

        public GetStadiumByIdHandler(IStadiumRepository repository)
        {
            _repository = repository;
        }

        public Task<Stadium> Handle(GetStadiumByIdQuery request, CancellationToken cancellationToken)
        {
            var stadium = _repository.GetStadiumById(request.Id);
            return stadium == null ? null : stadium;
        }
    }
}
