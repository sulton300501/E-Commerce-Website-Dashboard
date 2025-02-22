﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set;}
        public List<Product> Products { get; set; }
    }
}
