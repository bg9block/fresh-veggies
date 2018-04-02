using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace ShoppingCart.API.Tests
{
    public static class TestHelper
    {
        static TestHelper()
        {
            var webHostBuilder = new WebHostBuilder();
            webHostBuilder.UseStartup<Startup>();
            TestServer = new TestServer(webHostBuilder);
        }
        
        private static TestServer TestServer { get; }

        public static TestServer GetTestServer()
        {
            return TestServer;
        }
    }
}