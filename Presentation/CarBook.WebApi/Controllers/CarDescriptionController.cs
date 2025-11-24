using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarDescriptionByCarId(int id)
        {
            var value =await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(value);
        }
    }
}
