using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebService.Models
{
    //Описание модели
    public class RootObject
    {
        public Results results { get; set; }
        public string status { get; set; }
    }
}