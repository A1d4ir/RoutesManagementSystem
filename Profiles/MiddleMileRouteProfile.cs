using AutoMapper;

namespace RoutesManagementSystem.API.Profiles
{
    public class MiddleMileRouteProfile : Profile
    {
        public MiddleMileRouteProfile()
        {
            // Get by id
            CreateMap<Entities.Route, Models.MiddleMileRouteGetByIdDto>();
            CreateMap<Models.MiddleMileRouteGetByIdDto, Entities.Route>();

            // POST
            CreateMap<Entities.MiddleMileRoute, Models.MiddleMileRoutePostRequestDto>();
            CreateMap<Models.MiddleMileRoutePostRequestDto, Entities.MiddleMileRoute>();

            // PATCH ROUTE BASE
            CreateMap<Entities.Route, Models.MiddleMileRouteForUpdateDto>();
            CreateMap<Models.MiddleMileRouteForUpdateDto, Entities.Route>();
            // PATCH LAST MILE ROUTE COMPLEMENT
            CreateMap<Entities.MiddleMileRoute, Models.MiddleMileRouteForUpdateDto>();
            CreateMap<Models.MiddleMileRouteForUpdateDto, Entities.MiddleMileRoute>();
        }
    }
}
