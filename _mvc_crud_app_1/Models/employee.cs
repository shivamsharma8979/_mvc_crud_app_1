using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _mvc_crud_app_1.Models
{
    public class employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public long mobile { get; set; }
    }
}