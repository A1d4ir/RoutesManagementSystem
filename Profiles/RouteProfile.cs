﻿using AutoMapper;

namespace RoutesManagementSystem.API.Profiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<Entities.Route, Models.LastMileRoutesPostRequestDto>();
            CreateMap<Models.LastMileRoutesPostRequestDto, Entities.Route>();
        }
    }
}