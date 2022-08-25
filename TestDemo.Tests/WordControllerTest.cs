using Moq;
namespace Stack.Tests
{
    public class WordControllerTest
    {
        IReverseService mockService;
        Mock<IReverseService> mock;

        public WordControllerTest()
        {
            mock = new Mock<IReverseService>();
            mock.Setup(s => s.Reverse(It.IsAny<string>())).Returns("oof");
            mockService = mock.Object;

        }
        [Fact]
        public void happyPath()
        {
            var expected = "OOF";
            var actual = new WordController(mockService).RefactoredReverseAndUpcase("foo");
            Assert.Equal(expected, actual);

            mock.Verify(s => s.Reverse(It.IsAny<string>()), Times.Once);
        }
        [Fact]
        public void HandlesExceptionGracefully()
        {
            var mock = new Mock<IReverseService>();
            mock.Setup(s => s.Reverse(It.IsAny<string>())).Throws(new IOException("Boom!"));
            var mockService = mock.Object;

            var actual = new WordController(mockService).RefactoredReverseAndUpcase("foo");
            Assert.Equal(default(string), actual);

            mock.Verify(s => s.Reverse(It.IsAny<string>()), Times.Once);
        }

    }

}