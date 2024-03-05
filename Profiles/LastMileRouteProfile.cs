using AutoMapper;

namespace RoutesManagementSystem.API.Profiles
{
    public class LastMileRouteProfile : Profile
    {
        public LastMileRouteProfile()
        {
            CreateMap<Entities.LastMileRoute, Models.LastMileRoutesPostRequestDto>();
            CreateMap<Models.LastMileRoutesPostRequestDto, Entities.LastMileRoute>();
        }
    }
}