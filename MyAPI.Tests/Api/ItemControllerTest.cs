﻿using MyAPI.DomainModel.Entities;
using Rdcs.Test;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace MyAPI.Tests.Api
{
    public class ItemControllerTest
    {
        private string baseRoute = "/api/item";

        [Fact]
        public async void Test_Default_Get()
        {
            HttpClient client = new TestClientProvider().Client;
            HttpResponseMessage response = await client.GetAsync(baseRoute);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Test_Default_Post()
        {
            HttpClient client = new TestClientProvider().Client;
            StringContent content = TestUtils.RequestBody("Nome de um item");
            HttpResponseMessage responsePost = await client.GetAsync(baseRoute);
            Assert.Equal(HttpStatusCode.OK, responsePost.StatusCode);

            HttpResponseMessage responseGet = await client.GetAsync(baseRoute);
            List<Item> itemList = await TestUtils.ReadResponse<List<Item>>(responseGet);
            Assert.NotEmpty(itemList);
        }

    }
}
