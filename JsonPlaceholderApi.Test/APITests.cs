using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Xunit;

namespace JsonPlaceholderApi.Test
{
    public class APITests
    {
        [Theory(DisplayName = "StatusCode Tests for API and checking if the content returned in the body of the response is not empty")]

        [InlineData("https://jsonplaceholder.typicode.com/posts", HttpStatusCode.OK)]
        [InlineData("https://jsonplaceholder.typicode.com/photos", HttpStatusCode.OK)]
        [InlineData("https://jsonplaceholder.typicode.com/comments", HttpStatusCode.OK)]
        [InlineData("https://jsonplaceholder.typicode.com/comments?postId=1", HttpStatusCode.OK)]
        public void Statuscodetest(string url, HttpStatusCode expectedresult)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            Assert.Equal(expectedresult, response.StatusCode);
            Assert.NotEmpty(response.Content);
        }

        [Fact(DisplayName = "Checking Number of Comments for endpoint: https://jsonplaceholder.typicode.com/comments?postId=2")]
        public void ShouldCheckNumberofCommentsAfterDeserializeJsonBody()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/comments?postId=2");
            RestRequest request = new RestRequest(Method.GET);
            
            IRestResponse response1 = client.Execute(request);
            var objectresponse = JsonConvert.DeserializeObject<CommentModel[]>(response1.Content);

            Assert.Equal(5, objectresponse.Length);

        }



    }
}
