using MovieRentalAppMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalAppMVC.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        // /api/newrentalscontroller/createnewrental
        [HttpPost]
        public IHttpActionResult CreateNewRental (NewRentalDto newRental)
        {
            return NotFound();
        }

        
    }
}
