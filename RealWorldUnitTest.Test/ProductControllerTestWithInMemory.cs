using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealWorldUnitTest.Web.Controllers;
using RealWorldUnitTest.Web.Models;
using Xunit;

namespace RealWorldUnitTest.Test
{
    public class ProductControllerTestWithInMemory : ProductControllerTest
    {
        public ProductControllerTestWithInMemory()
        {
            SetContextOptions(new DbContextOptionsBuilder<UdemyUnitTestDBContext>().UseInMemoryDatabase("UdemyUnitTestDB").Options);
        }

        [Fact]
        public async Task Create_ModelValidProduct_ReturnsRedirectToActionWithSaveProduct()
        {
            var newProduct = new Product { Name = "Kalem 30", Price = 200, Stock = 100 };

            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var category = context.Category.First();

                newProduct.CategoryId = category.Id;

                var controller = new ProductsController(context);

                var result =await controller.Create(newProduct);

                var redirect = Assert.IsType<RedirectToActionResult>(result);

                Assert.Equal("Index", redirect.ActionName);


            }

            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var product = context.Products.FirstOrDefault(x => x.Name == newProduct.Name);

                Assert.Equal(newProduct.Name, product.Name);

            }

        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteCategory_ExistCategoryId_DeletedAllProducts(int categoryId)
        {

            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var category = await context.Category.FindAsync(categoryId);

                context.Category.Remove(category);

                context.SaveChanges();

            }

            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var products = await context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();

                Assert.Empty(products);
            }

        }





    }
}
