using AutoMapper;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Models;
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

        public async Task<Stadium> CreateStadium(Stadium stadium)
        {
            if(stadium != null)
            {
                throw new NotModifiedException("Cannot add new stadium");
            }
             _database.Stadiums.Add(stadium);
            await _database.SaveChangesAsync();
            return stadium;

        }

        public async Task<Stadium> GetStadiumByClubId(int id)
        {
            var stadium = await _database.Stadiums.SingleOrDefaultAsync(x => x.ClubId == id);
            if(stadium != null)
            {
                return stadium;
            }
            throw new NotFoundException($"Stadiums with ClubId {id} not found!");
        }

        public async Task<Stadium> GetStadiumById(int id)
        {
            var stadium = await _database.Stadiums.SingleOrDefaultAsync(x => x.Id == id);
            if(stadium != null)
            {
                return stadium;
            }
            throw new NotFoundException($"Stadiums with id {id} not found!");
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
