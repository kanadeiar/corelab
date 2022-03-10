﻿namespace WebApp.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
