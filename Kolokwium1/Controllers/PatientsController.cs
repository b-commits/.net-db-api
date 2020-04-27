using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientDbService _service;
        public PatientsController(IPatientDbService service)
        {
            _service = service;
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePatient(int id)
        {
            return StatusCode(200, _service.DeletePatient(id));
        }

    }
}