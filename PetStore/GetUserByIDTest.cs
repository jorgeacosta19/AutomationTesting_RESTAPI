
using RestSharp;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp.Serialization.Json;


namespace PetStore
{
    [TestFixture]
    public class GetUserByIDTest
    {
        [Test]
        public void TestGETUserbyID()
        {
            var client = new RestClient("https://petstore.swagger.io/v2/");
            var request = new RestRequest("user/{username}", Method.GET);
            request.AddUrlSegment("username", "jorge19");

            var response = client.Execute(request);

            //To get rid of the object
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["lastName"];

            Assert.That(result, Is.EqualTo("Acosta"), "Surname is not correct");

            //To make the test fail 
            //Assert.That(result, Is.EqualTo("Borg"), "Surname is not correct");

        }


    }

}
