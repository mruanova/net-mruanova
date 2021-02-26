using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testMvcNoHttps.Models
{
    public class Response
    {
        //[Key]
        public int statusCode { get; set; }
        public Object headers { get; set; }
        public Body body { get; set; }
    }
}