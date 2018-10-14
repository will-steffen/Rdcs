using MyAPI.DataAccess.Entities;
using MyAPI.DomainModel;
using MyAPI.DomainModel.Entities;
using MyAPI.Services.Entities;
using Rdcs.Attributes;
using Rdcs.Test;
using System;
using System.Net.Http;
using Xunit;

namespace MyAPI.Tests.Services
{
    public class ItemServiceTest : IClassFixture<RdcsDependencyFixture<ApplicationContext>>
    {
        ItemService itemService;
        ItemDataAccess itemDataAccess;

        public ItemServiceTest(RdcsDependencyFixture<ApplicationContext> fixture)
        {            
            itemService = fixture.Resolve<ItemService>();
            itemDataAccess = fixture.Resolve<ItemDataAccess>();
        }

        [Fact]
        public void Test_Create()
        {
            Item item = itemService.Create("um Nome");
            itemDataAccess.Save(item);
            Assert.True(item.Id > 0);
        }
    }
}
