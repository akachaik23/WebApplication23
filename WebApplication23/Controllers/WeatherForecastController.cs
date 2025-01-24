using Microsoft.AspNetCore.Mvc;

namespace WebApplication23.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IServiceBusTopic _serviceBusTopic;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IServiceBusTopic serviceBusTopic, 
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _serviceBusTopic = serviceBusTopic;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var data = _serviceBusTopic.GetData();
            var domain = _httpContextAccessor.HttpContext?.Request.Host.Host;

            return Ok(data);
        }
    }

    public interface IMyService
    {
    }

    public class MyService : IMyService
    {
    }
}
