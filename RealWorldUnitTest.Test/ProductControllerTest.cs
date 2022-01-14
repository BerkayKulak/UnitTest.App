﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RealWorldUnitTest.Web.Controllers;
using RealWorldUnitTest.Web.Models;
using RealWorldUnitTest.Web.Repository;
using Xunit;

namespace RealWorldUnitTest.Test
{

    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _mockRepo;

        private readonly ProductsController _controller;

        private List<Product> _products;

        public ProductControllerTest()
        {
            _mockRepo = new Mock<IRepository<Product>>();
            _controller = new ProductsController(_mockRepo.Object);
            _products = new List<Product>{
                new Product{Id = 1,Name = "Kalem",Price = 100,Stock = 50,Color = "Kırmızı"},
                new Product { Id = 2, Name = "Defter", Price = 200, Stock = 500, Color = "Mavi" } };


        }

        [Fact]
        public async void Index_ActionExecutes_ReturnView()
        {
            var result = await _controller.Index();

            Assert.IsType<ViewResult>(result);


        }

        [Fact]
        public async void Index_ActionExecutes_ReturnProductList()
        {
            _mockRepo.Setup(x => x.GetAll()).ReturnsAsync(_products);

            var result = await _controller.Index();

            // geriye result dönüyor mu
            var viewResult = Assert.IsType<ViewResult>(result);

            // Modelim bir productList mi onu kontrol ettim
            var productList = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);

            // liste eleman sayısı 2 mi
            Assert.Equal<int>(2,productList.Count());

        }
    }
}
