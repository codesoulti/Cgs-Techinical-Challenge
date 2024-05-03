using Cds.Technical.Challenge.Application.Contracts;
using Moq;

namespace Cgs.Technical.Challenge.HttpApi.NumberDecompositions.Tests
{
    public class NumberDecompositionPrimeControllerTest
    {
        private readonly NumberDecompositionPrimeController _controller;
        private readonly Mock<INumberDecompositonPrimeAppService> _appServiceMock;

        public NumberDecompositionPrimeControllerTest()
        {
            _appServiceMock = new Mock<INumberDecompositonPrimeAppService>();
            _controller = new NumberDecompositionPrimeController(_appServiceMock.Object);
        }

        [Fact]
        public void CalcularDecompostion_ReturnsResultFromAppService()
        {
            var input = new NumberDecompositionDto { Number = 10 };
            var expectedResult = new List<long> { 1, 2, 5, 10 };

            _appServiceMock.Setup(x => x.CalcularDecompostionPrime(input)).Returns(expectedResult);

            var result = _controller.CalcularDecompostionPrime(input);

            Assert.Equal(expectedResult, result);
        }
    }
}