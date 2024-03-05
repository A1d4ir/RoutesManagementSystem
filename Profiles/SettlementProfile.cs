using AutoMapper;

namespace RoutesManagementSystem.API.Profiles
{
    public class SettlementProfile : Profile
    {
        public SettlementProfile()
        {
            CreateMap<Entities.Settlement, Models.SettlementDto>();
            CreateMap<Models.SettlementDto, Entities.Settlement>();
        }
    }
}
