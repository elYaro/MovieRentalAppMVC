using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalAppMVC.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }

        public List<int> MovieIdsList { get; set; }


    }
}