using Cds.Technical.Challenge.Application.Contracts;
using Cds.Technical.Challenge.Application.Contracts.Mapper;
using Cds.Technical.Challenge.Domain.NumberDecompositions;
using Moq;

namespace Cgs.Technical.Challenge.Application.NumberDecompositions.Tests
{
    public class NumberDecompositonPrimeAppServiceTest
    {
        private readonly NumberDecompositonPrimeAppService _numberDecompositonPrimeAppService;
        private readonly Mock<NumberDecompositionManager> _numberDecompositionManagerMock;
        private readonly Mock<IObjectMapper> _objectMapperMock;

        public NumberDecompositonPrimeAppServiceTest()
        {
            _numberDecompositionManagerMock = new Mock<NumberDecompositionManager>();
            _objectMapperMock = new Mock<IObjectMapper>();
            _numberDecompositonPrimeAppService = new NumberDecompositonPrimeAppService(_numberDecompositionManagerMock.Object, _objectMapperMock.Object);
        }

        [Fact]
        public void CalcularDecompostionPrime_ShouldMapInputToNumberDecomposition()
        {
            // Arrange
            var input = new NumberDecompositionDto { Number = 10 };
            var expectedMapper = new NumberDecomposition { Number = 10 };

            _objectMapperMock.Setup(x => x.Map<NumberDecompositionDto, NumberDecomposition>(input)).Returns(expectedMapper);

            // Act
            _numberDecompositonPrimeAppService.CalcularDecompostionPrime(input);

            // Assert
            _objectMapperMock.Verify(x => x.Map<NumberDecompositionDto, NumberDecomposition>(input), Times.Once);
        }

        [Fact]
        public void CalcularDecompostionPrime_ShouldCallNumberDecompositionManager()
        {
            // Arrange
            var input = new NumberDecompositionDto { Number = 10 };
            var expectedMapper = new NumberDecomposition { Number = 10 };
            var expectedList = new List<long> { 1, 2, 5, 10 };

            _numberDecompositionManagerMock.Setup(x => x.CalcularDecompostionPrime(expectedMapper)).Returns(expectedList);
            _objectMapperMock.Setup(x => x.Map<NumberDecompositionDto, NumberDecomposition>(input)).Returns(expectedMapper);

            // Act
            _numberDecompositonPrimeAppService.CalcularDecompostionPrime(input);

            // Assert
            _numberDecompositionManagerMock.Verify(x => x.CalcularDecompostionPrime(expectedMapper), Times.Once);
        }

        [Fact]
        public void CalcularDecompostion_ShouldReturnResultFromNumberDecompositionManager()
        {
            // Arrange
            var input = new NumberDecompositionDto { Number = 10 };
            var expectedMapper = new NumberDecomposition { Number = 10 };
            var expectedList = new List<long> { 1, 2, 5, 10 };

            _numberDecompositionManagerMock.Setup(x => x.CalcularDecompostionPrime(expectedMapper)).Returns(expectedList);
            _objectMapperMock.Setup(x => x.Map<NumberDecompositionDto, NumberDecomposition>(input)).Returns(expectedMapper);


            // Act
            var result = _numberDecompositonPrimeAppService.CalcularDecompostionPrime(input);

            // Assert
            Assert.Equal(expectedList, result);
        }
    }
}