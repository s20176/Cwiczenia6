using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zadanie1.Models.DTO;
using Zadanie1.Services;

namespace Zadanie1.Controllers
{
    [ApiController]
    [Route("api/prescriptions")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDbService _dbService;

        public PrescriptionController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getPrescription(int id)
        {
            try
            {
                PrescriptionDTO prescription = await _dbService.getPrescription(id);
                return Ok(prescription);
            }
            catch(Exception e)
            {
                if (e.Message.Equals("Recepta nie istnieje"))
                {
                    return NotFound(e.Message);
                }
                return StatusCode(500);
            }
            
        }
    }
}
