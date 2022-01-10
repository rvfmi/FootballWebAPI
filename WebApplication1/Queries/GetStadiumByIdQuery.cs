using Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Queries
{
    public class GetStadiumByIdQuery : IRequest<Stadium>
    {
        public int Id { get; set; }
        public GetStadiumByIdQuery(int id)
        {
            Id = id;
        }

    }
}
