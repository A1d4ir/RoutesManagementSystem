using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RoutesManagementSystem.API.Models;
using RoutesManagementSystem.API.Services;

namespace RoutesManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/last-mile-routes")]
    public class LastMileRoutesController : ControllerBase
    {
        private readonly ILastMileRoutesRepository _lastMileRoutesRepository;
        private readonly IRouteTypeRepository _routeTypeRepository;
        private readonly IMapper _mapper;

        public LastMileRoutesController(
            ILastMileRoutesRepository lastMileRoutesRepository,
            IMapper mapper,
            IRouteTypeRepository routeTypeRepository
        )
        {
            _lastMileRoutesRepository = lastMileRoutesRepository;
            _routeTypeRepository = routeTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<LastMileRouteGetByIdDto>> GetById(int id)
        {
            if( id < 0 )
            {
                return BadRequest();
            }
            // Find route
            var routeToReturn = await _lastMileRoutesRepository.GetLastMileRouteById(id);
            if (routeToReturn == null)
            {
                return NotFound();
            }

            if(routeToReturn.ProductType != 3)
            {
                return BadRequest("Unsupported productType");
            }

            LastMileRouteGetByIdDto lastMileRoute = _mapper.Map<LastMileRouteGetByIdDto>(routeToReturn);
            lastMileRoute.Identify = routeToReturn.LastMileRoute!.Identify;
            lastMileRoute.CityId = routeToReturn.LastMileRoute.CityId;
            lastMileRoute.ConfigurationType = routeToReturn.LastMileRoute.ConfigurationType.ToString();
            lastMileRoute.MaximumLoads = routeToReturn.LastMileRoute.MaximumLoads;
            lastMileRoute.MinimumLoads = routeToReturn.LastMileRoute.MinimumLoads;
            lastMileRoute.DaysForDelivery = routeToReturn.LastMileRoute.DaysForDelivery;
            ICollection<SettlementDto> settlements = new List<SettlementDto>();
            foreach (var settlement in routeToReturn.LastMileRoute.Settlements)
            {
                settlements.Add(_mapper.Map<SettlementDto>(settlement));
            }
            lastMileRoute.Settlements = settlements;

            return Ok(lastMileRoute);
        }

        [HttpPost]
        public async Task<ActionResult<PostResponseDto>> CreateRoute(LastMileRoutesPostRequestDto lastMileRoute)
        {
            List<string> errors = new List<string>();
            if (lastMileRoute.ProductType != 3)
            {
                errors.Add("Unsupported productType");
                return BadRequest(new { errors = errors });
            }

            // Verify the provided route type
            var routeTypeProvided = await _routeTypeRepository.GetRouteTypeAsync(lastMileRoute.RouteTypeId);
            if (routeTypeProvided == null)
            {
                errors.Add("Invalid routeType provided");
                return BadRequest(new { errors = errors });
            }

            var routeBase = _mapper.Map<Entities.Route>(lastMileRoute);
            var lastMileRouteEntity = _mapper.Map<Entities.LastMileRoute>(lastMileRoute);


            int routeIdSaved = await _lastMileRoutesRepository.AddLastMileRoute(routeBase, lastMileRouteEntity);

            return CreatedAtAction(nameof(CreateRoute), new PostResponseDto() { Id = routeIdSaved});
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdate(
            int id, 
            JsonPatchDocument<LastMileRouteForUpdateDto> routeToUpdate
        )
        {
            var routeEntity = await _lastMileRoutesRepository.GetLastMileRouteById(id);
            if (routeEntity == null)
            {
                return NotFound();
            }

            var routeToPatch = _mapper.Map<LastMileRouteForUpdateDto>(routeEntity);
            routeToUpdate.ApplyTo(routeToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!TryValidateModel(routeToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(routeToPatch, routeEntity);
            await _lastMileRoutesRepository.SaveChangesAsync();

            var lastMileRouteEntity = routeEntity.LastMileRoute;
            var lastMileRouteToPatch = _mapper.Map<LastMileRouteForUpdateDto>(lastMileRouteEntity);
            routeToUpdate.ApplyTo(lastMileRouteToPatch, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!TryValidateModel(lastMileRouteToPatch))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(lastMileRouteToPatch, lastMileRouteEntity);
            await _lastMileRoutesRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
