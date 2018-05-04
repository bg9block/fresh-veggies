using System.Net.Http;
using System.Threading.Tasks;
using FreshVeg.Common;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace FreshVeg.API.Tests.Controllers.CartController
{
    public class SayHello
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public SayHello()
        {
            _server = TestHelper.GetTestServer();
            _client = _server.CreateClient();
        }
        
        [Fact]
        public async Task ReturnsOk_WithHello()
        {
            //Arrange
            var name = "Ilia";
            var expectedResponseString = $"Hello {name}!";
            try
            {
                //Act
                Env.TestDbConnection.Open();
                var response = await _client.GetAsync($"/api/cart/sayHello?name={name}");
                response.EnsureSuccessStatusCode(); 
                var responseString = await response.Content.ReadAsStringAsync();
                
                //Assert
                Assert.Equal(expectedResponseString, responseString);
            }
            finally
            {
                Env.TestDbConnection.Close();
            }
        }
    }
}