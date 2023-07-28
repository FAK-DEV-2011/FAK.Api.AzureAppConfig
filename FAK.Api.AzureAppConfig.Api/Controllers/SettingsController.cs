using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Runtime;

namespace FAK.Api.AzureAppConfig.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {

        private readonly ILogger<SettingsController> _logger;
        private readonly IOptionsSnapshot<Settings> _settings;

        public SettingsController(IOptionsSnapshot<Settings> settings, ILogger<SettingsController> logger)
        {
            _logger = logger;
            _settings = settings;
        }

        [HttpGet(Name = "GetSettings")]
        public IActionResult GetSettings()
        {
            Settings settings = _settings.Value;
            return new OkObjectResult(settings);
        }
    }
}