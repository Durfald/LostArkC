using LostArkAPI.Other;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq.Expressions;

namespace LostArkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //    private bool Validate(long SteamId)
        //    {
        //        DateTime currentTime = DateTime.UtcNow;
        //        var date = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, 0, 0);
        //        var backdate = date.AddHours(-1);
        //        long unixTime = ((DateTimeOffset)date).ToUnixTimeSeconds();
        //        long backunixTime = ((DateTimeOffset)backdate).ToUnixTimeSeconds();
        //        var key = GetAPIKey();
        //        if (string.IsNullOrEmpty(key))
        //            return false;
        //        var tempkey = SHA256.sha3256_hash(SteamId.ToString() + unixTime);
        //        var backtempkey = SHA256.sha3256_hash(SteamId.ToString() + backunixTime);
        //        return key == tempkey || key == backtempkey;
        //    }



        //    private static readonly string[] Summaries = new[]
        //    {
        //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //    };

        //    private readonly ILogger<WeatherForecastController> _logger;

        //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //    {
        //        _logger = logger;
        //    }

        //    [HttpGet(Name = "GetWeathest")]
        //    public IEnumerable<object> Get()
        //    {
        //        return Enumerable.Range(1, 5).Select(index => new weather
        //        {
        //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //            TemperatureC = Random.Shared.Next(-20, 55),
        //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //    }
        //}

        //internal class weather
        //{
        //    public DateOnly Date { get; set; }
        //    public int TemperatureC { get; set; }
        //    public string Summary { get; set; }
        //}
    }
}
