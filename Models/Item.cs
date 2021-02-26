using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testMvcNoHttps.Models
{
    public class Item
    {
        [Key]
        public int ProjectId { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public Object Coordinates { get; set; }
    }
}