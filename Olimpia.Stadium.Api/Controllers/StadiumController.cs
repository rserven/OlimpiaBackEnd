using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Olimpia.Stadium.Api.Model;
using Olimpia.Stadium.Api.Service;
using Olimpia.Stadium.Api.Util;

namespace Olimpia.Stadium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly ILogger<StadiumController> _logger;

        public StadiumController(ILogger<StadiumController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("SetCapacity")]
        public async Task<bool> SetCapacity(Stadium stadium)
        {
            try
            {
                if (stadium.MaxCapacity == 0 || stadium.MaxCapacity > 100)
                    throw new Exception("Solicitud Invalida.");
                await StadiumService.SetCapacityAsync(stadium.MaxCapacity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw new ApplicationException(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCapacity")]
        public async Task<int> GetCapacity()
        {
            try
            {
                var max = await StadiumService.GetCapacityAsync();
                return max;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw new ApplicationException(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCapacityByGate")]
        public async Task<List<MyArray>> GetCapacityByGate()
        {
            try
            {

                var array = new List<MyArray>();

                foreach (Gate.CardinalDirection cardinal in (Gate.CardinalDirection[])Enum.GetValues(typeof(Gate.CardinalDirection)))
                {
                    var occupied = await GateService.GetChairs(cardinal.ToString());
                    int capacity;

                    switch (cardinal)
                    {
                        case Gate.CardinalDirection.North:
                            capacity = Constants.NorthMax - Constants.NorthMin;
                            break;
                        case Gate.CardinalDirection.South:
                            capacity = Constants.SouthMax - Constants.SouthMin;
                            break;
                        case Gate.CardinalDirection.West:
                            capacity = Constants.WestMax - Constants.WestMin;
                            break;
                        case Gate.CardinalDirection.East:
                            capacity = Constants.EastMax - Constants.EastMin;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    var serie = new List<Series>();
                    serie.Add(new Series
                    {
                        name = "Capacidad",
                        value = capacity + 1
                    });
                    serie.Add(new Series
                    {
                        name = "Ocupado",
                        value = occupied
                    });

                    array.Add(new MyArray
                    {
                        name = cardinal.ToString(),
                        series = serie
                    });
                }


                return array;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw new ApplicationException(ex.Message);
            }
        }

        public class Stadium
        {
            public int MaxCapacity { get; set; }
        }


        public class Series
        {
            public string name { get; set; }
            public int value { get; set; }
        }

        public class MyArray
        {
            public string name { get; set; }
            public List<Series> series { get; set; }
        }

        

    }
}
