using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using ShoppingCart.API.Models;
using ShoppingCart.Common;
using ShoppingCart.Data.Context;
using ShoppingCart.Models;
using ShoppingCart.Models.Enums;
using Xunit;

namespace ShoppingCart.API.Tests.Controllers.CartController
{
    public class GetTotalPrice
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public GetTotalPrice()
        {
            var webHostBuilder = new WebHostBuilder();
            webHostBuilder.UseStartup<Startup>();
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        
        [Fact]
        public async Task ReturnsOk_ForBasketWithGiftAmountVoucher()
        {
            //Arrange
            var product1 =     new Product() { Id = Guid.NewGuid(), Name = "Hat", Price = 10.50, Category = ProductCategory.Clothes};
            var product2 =     new Product() { Id = Guid.NewGuid(), Name = "Jumper", Price = 54.65, Category = ProductCategory.Clothes };
            var giftVoucher =  new Voucher() { Id = Guid.NewGuid(), Name = "YYY-YYY", DiscountAmount = 5, Type = VoucherType.Gift};
            var orderModel =   new OrderModel()
            {
                Products = new List<OrderProductModel>()
                {
                    new OrderProductModel() { ProductId = product1.Id, Amount = 1 },
                    new OrderProductModel() { ProductId = product2.Id, Amount = 1 },
                },
                VoucherIds = new List<Guid>() { giftVoucher.Id }
            };
            var expectedTotalPrice = 60.15;
            
            try
            {
                SeedDb(new List<Product> {product1, product2}, new List<Voucher>{giftVoucher});

                //Act
                var response = await _client.PostAsync("/api/cart/priceTotal", new StringContent(JsonConvert.SerializeObject(orderModel)));
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                
                //Assert
                Assert.True(double.TryParse(responseString, out var actualTotalPrice));
                Assert.Equal(expectedTotalPrice, actualTotalPrice);
            }
            finally
            {
                //database flushes
                Env.TestDbConnection.Close();
            }
        }

        [Fact]
        public async Task ReturnsMessage_ForTwoClothesAndHeadGearOfferVoucher()
        {
            //Arrange
            var product1 = new Product() { Id = Guid.NewGuid(), Name = "Hat", Price = 25.00, Category = ProductCategory.Clothes };
            var product2 = new Product() { Id = Guid.NewGuid(), Name = "Jumper", Price = 26.00, Category = ProductCategory.Clothes };
            var offerVoucher = new Voucher() 
                { Id = Guid.NewGuid(), Name = "YYY-YYY", DiscountAmount = 5, Type = VoucherType.Offer, Threshhold = 50, 
                    OfferProductCategory = ProductCategory.HeadGear };
            var orderModel = new OrderModel()
            {
                Products = new List<OrderProductModel>()
                {
                    new OrderProductModel() {ProductId = product1.Id, Amount = 1},
                    new OrderProductModel() {ProductId = product2.Id, Amount = 1},
                },
                VoucherIds = new List<Guid>() {offerVoucher.Id}
            };
            var expectedTotalPrice = 60.15;

            try
            {
                SeedDb(new List<Product> {product1, product2}, new List<Voucher>{offerVoucher});

                //Act
                var response = await _client.PostAsync("/api/cart/priceTotal",
                    new StringContent(JsonConvert.SerializeObject(orderModel)));
                var responseString = await response.Content.ReadAsStringAsync();

                //TODO: ASSERT INCOMING MESSAGE
                //Assert
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
                
            }
            finally
            {
                Env.TestDbConnection.Close();
            }
        }
        
        [Fact]
        public async Task ReturnsOk_ForThreeProductsWithHeadGearOfferVoucher()
        {
            //Arrange
            var product1 =     new Product() { Id = Guid.NewGuid(), Name = "Hat", Price = 25, Category = ProductCategory.Clothes};
            var product2 =     new Product() { Id = Guid.NewGuid(), Name = "Jumper", Price = 26, Category = ProductCategory.Clothes };
            var product3 =     new Product() { Id = Guid.NewGuid(), Name = "Head Light", Price = 3.50, Category = ProductCategory.HeadGear };
            var offerVoucher =  new Voucher() 
                            { Id = Guid.NewGuid(), Name = "YYY-YYY", DiscountAmount = 5, Threshhold = 50, 
                                OfferProductCategory = ProductCategory.HeadGear, Type = VoucherType.Offer};
            var orderModel =   new OrderModel()
            {
                Products = new List<OrderProductModel>()
                {
                    new OrderProductModel() { ProductId = product1.Id, Amount = 1 },
                    new OrderProductModel() { ProductId = product2.Id, Amount = 1 },
                    new OrderProductModel() { ProductId = product3.Id, Amount = 1 },
                },
                VoucherIds = new List<Guid>() { offerVoucher.Id }
            };
            var expectedTotalPrice = 51;
            
            try
            {
                SeedDb(new List<Product> {product1, product2, product3}, new List<Voucher>{offerVoucher});

                //Act
                var response = await _client.PostAsync("/api/cart/priceTotal",
                    new StringContent(JsonConvert.SerializeObject(orderModel)));
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();

                //Assert
                Assert.True(double.TryParse(responseString, out var actualTotalPrice));
                Assert.Equal(expectedTotalPrice, actualTotalPrice);
            }
            finally
            {
                //database flushes
                Env.TestDbConnection.Close();
            }
        }
        
        [Fact]
        public async Task ReturnsOk_ForTwoValidProductsWithTwoValidVouchers()
        {
            //Arrange
            var product1 =     new Product() { Id = Guid.NewGuid(), Name = "Hat", Price = 25, Category = ProductCategory.Clothes};
            var product2 =     new Product() { Id = Guid.NewGuid(), Name = "Jumper", Price = 26, Category = ProductCategory.Clothes };
            var offerVoucher =  new Voucher() { Id = Guid.NewGuid(), Name = "YYY-YYY", DiscountAmount = 5, Type = VoucherType.Gift};
            var giftVoucher =  new Voucher() { Id = Guid.NewGuid(), Name = "YYY-YYY", DiscountAmount = 5, Threshhold = 50, Type = VoucherType.Offer};
            var orderModel =   new OrderModel()
            {
                Products = new List<OrderProductModel>()
                {
                    new OrderProductModel() { ProductId = product1.Id, Amount = 1 },
                    new OrderProductModel() { ProductId = product2.Id, Amount = 1 },
                },
                VoucherIds = new List<Guid>() { offerVoucher.Id, giftVoucher.Id}
            };
            var expectedTotalPrice = 51;
            
            try
            {
                SeedDb(new List<Product> {product1, product2}, new List<Voucher>{offerVoucher, giftVoucher});

                //Act
                var response = await _client.PostAsync("/api/cart/priceTotal",
                    new StringContent(JsonConvert.SerializeObject(orderModel)));
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();

                //Assert
                Assert.True(double.TryParse(responseString, out var actualTotalPrice));
                Assert.Equal(expectedTotalPrice, actualTotalPrice);
            }
            finally
            {
                //database flushes
                Env.TestDbConnection.Close();
            }
        }

        private void SeedDb(List<Product> products, List<Voucher> vouchers)
        {
            // In-memory database only exists while the connection is open
            Env.TestDbConnection.Open();

            var options = new DbContextOptionsBuilder<ShoppingCartContext>()
                .UseSqlite(Env.TestDbConnection)
                .Options;

            using (var context = new ShoppingCartContext(options))
            {
                context.Database.EnsureCreated();
                context.Products.AddRange(products);
                context.Vouchers.AddRange(vouchers);
                context.SaveChanges();
            }
        }
    }
}