using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Olimpia.Stadium.Api.Model;
using Olimpia.Stadium.Api.Service;

namespace Olimpia.Stadium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("AddPerson")]
        public async Task<bool> AddPerson([FromBody] AddPersonModel addPerson)
        {
            try
            {
                var cardinalDirection = (Gate.CardinalDirection)Enum.Parse(typeof(Gate.CardinalDirection), addPerson.Location);
                if (addPerson.DocumentId == 0)
                    throw new Exception("Solicitud Invalida: Documento Id igual a 0.");

                if (string.IsNullOrEmpty(addPerson.FullName))
                    throw new Exception("Solicitud Invalida: Nombre invalido.");

                if (string.IsNullOrEmpty(addPerson.Location.ToString()))
                    throw new Exception("Solicitud Invalida: Puerta Invalida.");

                await PersonService.AddPersonAsync(addPerson.DocumentId, addPerson.FullName, cardinalDirection.ToString());
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DelPerson")]
        public async Task<bool> DelPerson(int documentId)
        {
            try
            {
                if (documentId == 0)
                    throw new Exception("Solicitud Invalida.");
                var isDeleted = await PersonService.DelPersonAsync(documentId);
                return isDeleted;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public class AddPersonModel
        {
            public int DocumentId { get; set; }
            public string FullName { get; set; }
            public string Location { get; set; }
        }
    }
}
