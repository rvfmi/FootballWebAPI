using Infrastructure.Models;
using Infrastructure.ModelsDTO.Stadium;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Queries
{
    public class GetAllStadiumsQuery : IRequest<List<StadiumDTO>>
    {
        
    }
}
