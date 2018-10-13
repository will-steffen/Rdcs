using MyAPI.DomainModel.Entities;
using Rdcs.Test;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Xunit;


namespace MyAPI.Tests.Api
{
    public class ItemControllerTest
    {
        private static string baseRoute = "/api/item";

        [Fact]
        public async void Test_Default_Get()
        {
            using (HttpClient client = new TestClientProvider().Client)
            {
                HttpResponseMessage response = await client.GetAsync(baseRoute);
                Assert.True(response.StatusCode == HttpStatusCode.OK);
            }
        }

        [Fact]
        public async void Test_Default_Post()
        {
            using (HttpClient client = new TestClientProvider().Client)
            {                
                HttpResponseMessage response = await client.PostAsync(baseRoute, TestUtils.RequestBody("Um nome Legal"));
                Assert.True(response.StatusCode == HttpStatusCode.OK);

                HttpResponseMessage r2 = await client.GetAsync(baseRoute);
                List<Item> result = await TestUtils.ReadResponse<List<Item>>(r2);
                Assert.True(result.Count == 1);
            }
        }

    }
}
