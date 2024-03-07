using AutoMapper;

namespace RoutesManagementSystem.API.Profiles
{
    public class LastMileRouteProfile : Profile
    {
        public LastMileRouteProfile()
        {
            // POST
            CreateMap<Entities.LastMileRoute, Models.LastMileRoutesPostRequestDto>();
            CreateMap<Models.LastMileRoutesPostRequestDto, Entities.LastMileRoute>();

            // Get
            CreateMap<Entities.Route, Models.LastMileRouteGetByIdDto>();
            CreateMap<Models.LastMileRouteGetByIdDto, Entities.Route>();

            // PATCH ROUTE BASE
            CreateMap<Entities.Route, Models.LastMileRouteForUpdateDto>();
            CreateMap<Models.LastMileRouteForUpdateDto, Entities.Route>();
            // PATCH LAST MILE ROUTE COMPLEMENT
            CreateMap<Entities.LastMileRoute, Models.LastMileRouteForUpdateDto>();
            CreateMap<Models.LastMileRouteForUpdateDto, Entities.LastMileRoute>();
        }
    }
}