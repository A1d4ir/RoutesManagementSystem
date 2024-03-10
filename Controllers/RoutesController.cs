using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoutesManagementSystem.API.Models;
using RoutesManagementSystem.API.Services;
using System.Text.Json;

namespace RoutesManagementSystem.API.Controllers
{
    [Route("api/routes")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;
        const int maxRoutesPageSize = 20;

        public RoutesController(IRouteService routeService, IMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteBaseDto>>> GetRoutes(
            string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10
        )
        {
            if(pageSize > maxRoutesPageSize)
            {
                pageSize = maxRoutesPageSize;
            }

            var (routeEntities, paginationMetadata) = await _routeService
                .GetRoutesAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<RouteBaseDto>>(routeEntities));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoute(int id)
        {
            List<string> errors = new List<string>();
            if(id < 0)
            {
                errors.Add("Invalid id");
                return BadRequest(new { errors = errors});
            }

            var routeExist = await _routeService.RouteExist(id);
            if(routeExist == null)
            {
                return NotFound();
            }

            _routeService.DeleteRoute(routeExist);
            await _routeService.SaveChangesAsync();

            return NoContent();
        }
    }
}
