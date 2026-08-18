using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace API.IntergrationTests
{
    public class ToDoControllerTest
    {
        [Fact]
        public async Task GetToDoList_ReturnsOkResponse()
        {   
            // Arrange
            var client = new TestClientProvider().Client;

            // Act
            var response = await client.GetAsync("/api/todo");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetToDoDetail_ReturnsOkResponse()
        {
            // Arrange
            var client = new TestClientProvider().Client;

            // Act
            var response = await client.GetAsync("/api/todo/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
