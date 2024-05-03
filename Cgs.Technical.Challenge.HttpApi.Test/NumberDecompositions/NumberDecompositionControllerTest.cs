using Cds.Technical.Challenge.Application.Contracts;
using Moq;

namespace Cgs.Technical.Challenge.HttpApi.NumberDecompositions.Tests
{
    public class NumberDecompositionControllerTests
    {
        private readonly NumberDecompositionController _controller;
        private readonly Mock<INumberDecompositonAppService> _appServiceMock;

        public NumberDecompositionControllerTests()
        {
            _appServiceMock = new Mock<INumberDecompositonAppService>();
            _controller = new NumberDecompositionController(_appServiceMock.Object);
        }

        [Fact]
        public void CalcularDecompostion_ReturnsResultFromAppService()
        {
            var input = new NumberDecompositionDto { Number = 10 };
            var expectedResult = new List<long> { 1, 2, 5, 10 };

            _appServiceMock.Setup(x => x.CalcularDecompostion(input)).Returns(expectedResult);

            var result = _controller.CalcularDecompostion(input);

            Assert.Equal(expectedResult, result);
        }
    }
}