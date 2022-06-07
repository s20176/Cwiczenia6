using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zad1.Models;
using Zadanie1.Models.DTO;
using Zadanie1.Services;

namespace Zadanie1.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public DoctorsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getDoctor(int id)
        {
            
            try
            {
                Doctor doctor = _dbService.getDoctor(id).Result;
                if (doctor == null)
                {
                    return NotFound();
                }
                DoctorDTO dto = new DoctorDTO
                {
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email
                };
                return Ok(dto);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> addDoctor(DoctorDTO dto)
        {
            try
            {
                Doctor doctor = new Doctor
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email
                };
                await _dbService.addDoctor(doctor);
                return Ok("Dodano doktora");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateDoctor(int id,DoctorDTO dto)
        {
            try
            {
                await _dbService.updateDoctor(id, dto);
                return Ok("Edytowano doktora");
            }
            catch(Exception e)
            {
                if (e.Message.Equals("Nie znaleziono doktora"))
                {
                    return NotFound(e.Message);
                }
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> removeDoctor(int id)
        {
            try
            {
                await _dbService.removeDoctor(id);
                return Ok("Usunięto doktora");
            }
            catch(Exception e)
            {
                if (e.Message.Equals("Nie znaleziono doktora"))
                {
                    return NotFound(e.Message);
                }
                return StatusCode(500);
            }
            
        }
    }
}
