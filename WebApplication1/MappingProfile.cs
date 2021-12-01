using AutoMapper;
using Infrastructure;
using Infrastructure.Models;
using Infrastructure.ModelsDTO.Club;
using Infrastructure.ModelsDTO.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubDTO>();
            CreateMap<CreateClubDTO, Club>();
            CreateMap<Player, PlayerDTO>();
        }
    }
}
