using AutoMapper;
using Infrastructure;
using Infrastructure.Exceptions;
using Infrastructure.ModelsDTO.Club;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Database;

namespace WebApplication1.Services
{
    public class ClubService : IClubRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public ClubService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<List<ClubDTO>> GetClubs()
        {
            var clubs = await _databaseContext.club
                .Include(x => x.Players)
                .ToListAsync();
            if (clubs.Count > 0)
            {
                var clubsDTO = _mapper.Map<List<ClubDTO>>(clubs);
                return clubsDTO;
            }
                throw new NotFoundException($"Clubs not found!");
        }
        public async Task<Club> GetOneClub(int id)
        {
            var clubs = await _databaseContext.club.SingleAsync(x => x.Id == id);
            if(clubs != null)
                return clubs;
            else
                throw new NotFoundException($"Club with id {id} not found!");
        }
        public async Task<Club> DeleteOneClub(int id)
        {
            var clubs = await _databaseContext.club.SingleAsync(x => x.Id == id);
            if (clubs != null)
            {
                _databaseContext.club.Remove(clubs);
                _databaseContext.SaveChanges();
                return clubs;
            }
            throw new NotModifiedException("Cannot delete club");
        }

        public async Task<Club> AddClub(CreateClubDTO club)
        {
            if (club is null)
                throw new NotModifiedException("Cannot add club");
            else
            {
                var clubToAdd = _mapper.Map<Club>(club);
                _databaseContext.club.Add(clubToAdd);
                await _databaseContext.SaveChangesAsync();
                return clubToAdd;
            }
        }

        public async Task<Club> Update(UpdateClubDTO clubs, int id)
        {
            var club = await _databaseContext.club.SingleOrDefaultAsync(x => x.Id == id);
            if (club is null || clubs is null)
                throw new NotModifiedException("Cannot modify club");
            else
            {
                club.Coach = clubs.Coach;
                club.TrophyCount = clubs.TrophyCount;
                club.BudgetInformation = clubs.BudgetInformation;
                await _databaseContext.SaveChangesAsync();
                return club;
            }
        }

    }
}
