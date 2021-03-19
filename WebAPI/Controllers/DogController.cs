using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class DogController : ApiController
    {
        // GET: https://localhost:44356/api/dog
        public IEnumerable<Dog> Get()
        {
            return new DogDB().Select();
        }

        // POST https://localhost:44356/api/dog
        public bool Post([FromBody] Dog dog)
        {
            return new DogDB().Insert(dog);
        }
    }
}