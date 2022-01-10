using Infrastructure.Interfaces;
using Infrastructure.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Commands;

namespace WebApplication1.Handlers
{
    public class CreateStadiumHandler : IRequestHandler<CreateStadiumCommand, Stadium>
    {
        private readonly IStadiumRepository _repository;
        private readonly ILogger<CreateStadiumHandler> _logger;

        public CreateStadiumHandler(IStadiumRepository repository, ILogger<CreateStadiumHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Stadium> Handle(CreateStadiumCommand request, CancellationToken cancellationToken)
        {
            var stadium = await _repository.CreateStadium(request.stadium);
            _logger.LogInformation($"Create new stadium: {stadium.StadiumName}");
            return stadium;
        }
    }
}
