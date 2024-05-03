using Cds.Technical.Challenge.Application.Contracts;
using Cds.Technical.Challenge.Application.Contracts.Mapper;
using Cds.Technical.Challenge.Domain.NumberDecompositions;
using Moq;

namespace Cgs.Technical.Challenge.Application.NumberDecompositions.Tests
{
    public class NumberDecompositonAppServiceTests
    {
        private readonly NumberDecompositonAppService _numberDecompositonAppService;
        private readonly Mock<NumberDecompositionManager> _numberDecompositionManagerMock;
        private readonly Mock<IObjectMapper> _objectMapperMock;

        public NumberDecompositonAppServiceTests()
        {
            _numberDecompositionManagerMock = new Mock<NumberDecompositionManager>();
            _objectMapperMock = new Mock<IObjectMapper>();
            _numberDecompositonAppService = new NumberDecompositonAppService(_numberDecompositionManagerMock.Object, _objectMapperMock.Object);
        }

        [Fact]
        public void CalcularDecompostion_ShouldMapInputToNumberDecomposition()
        {
            // Arrange
            var input = new NumberDecompositionDto { Number = 10 };
            var expectedMapper = new NumberDecomposition { Number = 10 };

            _objectMapperMock.Setup(x => x.Map<NumberDecompositionDto, NumberDecomposition>(input)).Returns(expectedMapper);

            // Act
            _numberDecompositonAppService.CalcularDecompostion(input);

            // Assert
            _objectMapperMock.Verify(x => x.Map<NumberDecompositionDto, NumberDecomposition>(input), Times.Once);
        }

        [Fact]
        public void CalcularDecompostion_ShouldCallNumberDecompositionManager()
        {
            // Arrange
            var input = new NumberDecompositionDto { Number = 10 };
            var expectedMapper = new NumberDecomposition { Number = 10 };
            var expectedList = new List<long> { 1, 2, 5, 10 };

            _numberDecompositionManagerMock.Setup(x => x.CalcularDecompostion(expectedMapper)).Returns(expectedList);
            _objectMapperMock.Setup(x => x.Map<NumberDecompositionDto, NumberDecomposition>(input)).Returns(expectedMapper);

            // Act
            _numberDecompositonAppService.CalcularDecompostion(input);

            // Assert
            _numberDecompositionManagerMock.Verify(x => x.CalcularDecompostion(expectedMapper), Times.Once);
        }

        [Fact]
        public void CalcularDecompostion_ShouldReturnResultFromNumberDecompositionManager()
        {
            // Arrange
            var input = new NumberDecompositionDto { Number = 10 };
            var expectedMapper = new NumberDecomposition { Number = 10 };
            var expectedList = new List<long> { 1, 2, 5, 10 };

            _numberDecompositionManagerMock.Setup(x => x.CalcularDecompostion(expectedMapper)).Returns(expectedList);
            _objectMapperMock.Setup(x => x.Map<NumberDecompositionDto, NumberDecomposition>(input)).Returns(expectedMapper);


            // Act
            var result = _numberDecompositonAppService.CalcularDecompostion(input);

            // Assert
            Assert.Equal(expectedList, result);
        }
    }
}