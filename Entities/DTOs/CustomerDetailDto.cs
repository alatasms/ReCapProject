using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
