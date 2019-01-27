using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarsService_API.Controllers
{
    public class MarcaController : Controller
    {
        IMarcaService Service;
        public MarcaController (IMarcaService service)
        {
            Service = service;
        }
        [HttpGet]
        public IList<MarcaDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{MarcaId}")]
        public MarcaDTO Get(Guid MarcaId)
        {
            return Service.GetAll()
                .Where(x => x.MarcaId == MarcaId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] MarcaDTO marca)
        {
            Service.Insert(marca);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{MarcaId}")]
        public IActionResult Put(Guid MarcaId, [FromBody] MarcaDTO marca)
        {
            marca.MarcaId = MarcaId;
            Service.Update(marca);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{MarcaId}")]
        public IActionResult Delete(Guid MarcaId)
        {
            Service.Delete(MarcaId);
            return Ok(true);
        }
    }
}