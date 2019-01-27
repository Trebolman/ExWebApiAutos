using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOS;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsService_API.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        ICarService Service;
        public CarController(ICarService service)
        {
            Service = service;
        }
        [HttpGet]
        public IList<CarDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{IdCar}")]
        public CarDTO Get(Guid IdCar)
        {
            return Service.GetAll()
                .Where(x => x.IdCar == IdCar)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] CarDTO car)
        {
            Service.Insert(car);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{IdCar}")]
        public IActionResult Put(Guid IdCar, [FromBody] CarDTO car)
        {
            car.IdCar = IdCar;
            Service.Update(car);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{IdCar}")]
        public IActionResult Delete(Guid IdCar)
        {
            Service.Delete(IdCar);
            return Ok(true);
        }
    }
}