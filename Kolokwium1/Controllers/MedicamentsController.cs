using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1.Controllers
{
    [Route("api/medicaments")]
    [ApiController]
    public class MedicamentsController : ControllerBase
    {
        private IMedicamentDbService _service;
        public MedicamentsController(IMedicamentDbService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMedInfo(int id)
        {
            try
            {
                return StatusCode(200, _service.GetMedInfo(id));
            } catch (SqlException ex)
            {
                return StatusCode(400);
            }
        }

    }
}
