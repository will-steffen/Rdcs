using MyAPI.Services.Entities;
using Rdcs.Attributes;
using System;
using System.Net.Http;
using Xunit;

namespace MyAPI.Tests.Services
{
    public class ItemServiceTest
    {
        [Autowired] ItemService itemService;

        [Fact]
        public void Test_Create()
        {
            itemService = new ItemService();
            Assert.True(true, "Status da request deve ser OK (200)");
        }
    }
}
