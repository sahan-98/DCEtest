using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCStore.Models.BEL
{
    public class Customers
    {
        public int userId { get; set; }
        public String userName { get; set; }
        public String email { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public DateTime createdOn { get; set; }
        public Boolean IsActive { get; set; }
    }
}