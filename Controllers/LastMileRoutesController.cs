using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RoutesManagementSystem.API.Models;
using RoutesManagementSystem.API.Services;

namespace RoutesManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/last-mile-routes")]
    public class LastMileRoutesController : ControllerBase
    {
        private readonly ILastMileRoutesRepository _routesRepository;
        private readonly IRouteTypeRepository _routeTypeRepository;
        private readonly IMapper _mapper;

        public LastMileRoutesController(
            ILastMileRoutesRepository routesRepository,
            IMapper mapper,
            IRouteTypeRepository routeTypeRepository
        )
        {
            _routesRepository = routesRepository;
            _routeTypeRepository = routeTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetRouteById")]
        public ActionResult<RouteBaseDto> GetRouteById(int id)
        {
            // Find route
            var routeToReturn = RoutesDataStore.Current.Routes
                .FirstOrDefault(r => r.Id == id);

            if (routeToReturn == null)
            {
                return NotFound();
            }

            return Ok(routeToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<PostResponseDto>> CreateRoute(LastMileRoutesPostRequestDto lastMileRoute)
        {
            List<string> errors = new List<string>();
            // Verify the provided route type
            var routeTypeProvided = await _routeTypeRepository.GetRouteTypeAsync(lastMileRoute.RouteTypeId);
            if (routeTypeProvided == null)
            {
                errors.Add("Invalid routeType provided");
                return BadRequest(new { errors = errors });
            }

            var routeBase = _mapper.Map<Entities.Route>(lastMileRoute);
            var lastMileRouteEntity = _mapper.Map<Entities.LastMileRoute>(lastMileRoute);


            int routeIdSaved = await _routesRepository.AddLastMileRoute(routeBase, lastMileRouteEntity);

            return CreatedAtAction(nameof(CreateRoute), new PostResponseDto() { Id = routeIdSaved});
        }
    }
}
