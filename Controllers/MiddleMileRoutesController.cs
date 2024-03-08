using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RoutesManagementSystem.API.Models;
using RoutesManagementSystem.API.Services;

namespace RoutesManagementSystem.API.Controllers
{
    [Route("api/middle-mile-routes")]
    [ApiController]
    public class MiddleMileRoutesController : ControllerBase
    {
        private readonly IMiddleMileRouteRepository _middleMileRouteRepository;
        private readonly IRouteTypeRepository _routeTypeRepository;
        private readonly IMapper _mapper;

        public MiddleMileRoutesController(
            IMiddleMileRouteRepository middleMileRouteRepository,
            IRouteTypeRepository routeTypeRepository,
            IMapper mapper)
        {
            _middleMileRouteRepository = middleMileRouteRepository;
            _routeTypeRepository = routeTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetMiddleMileRouteById")]
        public async Task<ActionResult<MiddleMileRouteGetByIdDto>> GetById(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }
            // Find route
            var routeToReturn = await _middleMileRouteRepository.GetMiddleMileRouteById(id);
            if (routeToReturn == null)
            {
                return NotFound();
            }

            if(routeToReturn.ProductType != 2)
            {
                return BadRequest("Unsupported productType");
            }

            MiddleMileRouteGetByIdDto middleMileRouteToReturn = _mapper.Map<MiddleMileRouteGetByIdDto>(routeToReturn);
            middleMileRouteToReturn.DestinationBusinessUnit = routeToReturn.MiddleMileRoute!.DestinationBusinessUnit;
            middleMileRouteToReturn.Distance = routeToReturn.MiddleMileRoute.Distance;
            middleMileRouteToReturn.DeliveryTime = routeToReturn.MiddleMileRoute.DeliveryTime;
            return Ok(middleMileRouteToReturn);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoute(
            MiddleMileRoutePostRequestDto middleMileRouteToUpdate
        )
        {
            List<string> errors = new List<string>();
            if(middleMileRouteToUpdate.ProductType != 2)
            {
                errors.Add("Unsupported productType");
                return BadRequest(new { errors = errors });
            }

            // verify the provided route type
            var routeTypeProvided = await _routeTypeRepository.GetRouteTypeAsync(middleMileRouteToUpdate.RouteTypeId);
            if(routeTypeProvided == null)
            {
                errors.Add("Invalid routeType provided");
                return BadRequest(new { errors = errors });
            }

            var routeEntity = _mapper.Map<Entities.Route>(middleMileRouteToUpdate);
            var middleMileRouteEntity = _mapper.Map<Entities.MiddleMileRoute>(middleMileRouteToUpdate);

            int routeId = await _middleMileRouteRepository.AddMiddleMileRoute(routeEntity, middleMileRouteEntity);

            return Ok(new { id = routeId });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdate(
            int id,
            JsonPatchDocument<MiddleMileRouteForUpdateDto> routeToUpdate
        )
        {
            var routeEntity = await _middleMileRouteRepository.GetMiddleMileRouteById(id);

            if (routeEntity == null)
            {
                return NotFound();
            }

            List<string> errors = new List<string>();
            if (routeEntity.ProductType != 2)
            {
                errors.Add("Unsupported productType");
                return BadRequest(new { errors = errors });
            }

            var routeToPatch = _mapper.Map<MiddleMileRouteForUpdateDto>(routeEntity);
            routeToUpdate.ApplyTo(routeToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(routeToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(routeToPatch, routeEntity);
            await _middleMileRouteRepository.SaveChangesAsync();

            var middleMileRouteEntity = routeEntity.MiddleMileRoute;
            var middleMileRouteToPatch = _mapper.Map<MiddleMileRouteForUpdateDto>(middleMileRouteEntity);
            routeToUpdate.ApplyTo(middleMileRouteToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(middleMileRouteToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(middleMileRouteToPatch, middleMileRouteEntity);
            await _middleMileRouteRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
