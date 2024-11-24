﻿using ArsenalFansModel.Dto;
using ArsenalFansModel.Entities;
using ArsenalFansWebApp.Models;
using AutoMapper;

namespace ArsenalFansWebApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PlayerDto, Player>().ReverseMap();
            CreateMap<PlayerDto, PlayerViewModel>().ReverseMap();
        }
    }
}