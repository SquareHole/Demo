#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Talista.Demo.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public async IAsyncEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			for (var i = 0; i < 5; i++)
			{
				var weatherData = new WeatherForecast
				{
					Date = DateTime.Now.AddDays(i),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)]
				};

				_logger.LogInformation("Random weather data generated: {@weatherData}", weatherData);

				yield return await Task.FromResult(weatherData);
			}
		}
	}
}
