using WineFactory;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPITests
{
    [TestClass]
    public class HumanResourcesServiceTests
    {
        [TestMethod]
        public async Task Can_GetWines_Test()
        {
            // arrange
            HttpClient client = new HttpClient();
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7224/");
            // Sets the Accept header to "application/json".Setting this header tells the server to send data in JSON format.
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // act
            IEnumerable<Wine> wines = null;
            HttpResponseMessage response = await client.GetAsync(@"WineFactory/GetWines");
            if (response.IsSuccessStatusCode)
            {
                wines = await response.Content.ReadAsAsync<IEnumerable<Wine>>();
            }

            // assert
            Assert.IsNotNull(wines);
        }
    }
}