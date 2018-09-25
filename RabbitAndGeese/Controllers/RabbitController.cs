using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitAndGeese.DataAccess;
using RabbitAndGeese.Models;

namespace RabbitAndGeese.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitController : ControllerBase
    {
        private readonly RabbitStorage _storage;

        // adding a contructor to get rid of duplication of the sotrage variable
        public RabbitController()
        {
            _storage = new RabbitStorage();
        }

        // method
        [HttpPost] // we are adding so we need to use HTTPPOST
        public void AddACustomer(Rabbit  rabbit)
        {
            //var storage = new RabbitStorage();
            _storage.Add(rabbit); // do ctrl . to get rid of the red line under Add (it will  throw new statemnet under rabbit Stroage
        }

        [HttpPut("{id}/geese")] // puttig a goose onto a rabbit
        public IActionResult AddGooseToRabbit(int id, Goose goose)
        {
           
            var rabbit = _storage.GetById(id);

            // check to see if a rabbit is not null so it wont throw an excecption error 

            if (rabbit == null) return NotFound();

            rabbit.OwnedGeese.Add(goose);
            return Ok();
        }

        [HttpPut("{id}/saddles")] // updating a saddle on a rabbit
        public IActionResult ProcureGooseSaddle(int id, Saddle saddle)
        {
           
            var rabbit = _storage.GetById(id);

            // check to see if a rabbit is not null so it wont throw an excecption error 

            if (rabbit == null) return NotFound();
            rabbit.OwnedSaddle.Add(saddle);
            return Ok();
        }
    }
}