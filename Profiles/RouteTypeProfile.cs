using AutoMapper;

namespace RoutesManagementSystem.API.Profiles
{
    public class RouteTypeProfile : Profile
    {
        public RouteTypeProfile()
        {
            CreateMap<Entities.RouteType, Models.RouteTypeDto>();
            CreateMap<Models.RouteTypeDto, Models.RouteTypeDto>();
        }
    }
}
