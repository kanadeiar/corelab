using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Simple.Controllers;
using Simple.Models;
using Xunit;

namespace Simple.Tests
{
    public class HomeControllerTests
    {
        class FakeDataSource : IDataSource
        {
            public FakeDataSource(Product[] data) => Products = data;
            public IEnumerable<Product> Products { get; set; }
        }

        [Fact]
        public void IndexActionModelsIsComplete()
        {
            var products = new Product[]
            {
                new() { Name = "Каяк", Price = 275M },
                new() { Name = "Жакет", Price = 48.95M },
                new() { Name = "Кок", Price = 65.55M },
                new() { Name = "Зенус", Price = 21.1M },
            };
            IDataSource data = new FakeDataSource(products);
            var controller = new HomeController();
            controller.dataSource = data;
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
