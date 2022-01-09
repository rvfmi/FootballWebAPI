using Infrastructure.ModelsDTO.Stadium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IStadiumRepository
    {
        Task<List<StadiumDTO>> GetStadiums();
    }
}
