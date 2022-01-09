using AutoMapper;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.ModelsDTO.Stadium;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Database;

namespace WebApplication1.Services
{
    public class StadiumService : IStadiumRepository
    {
        private readonly DatabaseContext _database;
        private readonly IMapper _mapper;

        public StadiumService(DatabaseContext database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<List<StadiumDTO>> GetStadiums()
        {
            var stadium = await _database.Stadiums.ToListAsync();
            if(stadium.Count > 0)
            {
                var stadiumDTO = _mapper.Map<List<StadiumDTO>>(stadium);
                return stadiumDTO;
            }
            throw new NotFoundException($"Stadiums not found!");

        }
    }
}
