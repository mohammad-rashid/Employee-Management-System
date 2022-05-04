using Employee_Management_System.Context;
using Employee_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Employee_Management_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class EmployeeController : Controller
    {
        AppDbContext _repository;
        public EmployeeController(AppDbContext repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var keyvalueFromDb = _repository.employees.Find(id);
            if (keyvalueFromDb == null)
            {
                return NotFound();
            }
            return Ok(keyvalueFromDb);
        }

        [HttpPost]
        public IActionResult Post(Employee inputData)
        {
            var dbData = _repository.departments.Find(inputData.Id);
            if (dbData != null)
            {
                return Conflict();
            }

            try
            {
                _repository.employees.Add(inputData);
                _repository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(Employee inputData)
        {
            var dbData = _repository.employees.Find(inputData.Id);
            if (dbData == null)
            {
                return NotFound();
            }

            try
            {
                dbData.Id = inputData.Id;
                dbData.Name = inputData.Name;
                dbData.Surname = inputData.Surname;
                dbData.Address = inputData.Address;
                dbData.Qualification = inputData.Qualification;
                dbData.Contact = inputData.Contact;
                dbData.department = inputData.department;
                _repository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dbData = _repository.employees.Find(id);
            if (dbData == null)
            {
                return NotFound();
            }
            try
            {
                _repository.employees.Remove(dbData);
                _repository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

}
