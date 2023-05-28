using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Domain;
using Moq;

namespace GestionDeProductos.Test
{
    public class DepositoServiceTests
    {
        [Fact]
        public async Task GetDepositoProduct_Should_Return_ProductoDeposito()
        {
            // Arrange
            var depositoId = 1;
            var productoId = 2;
            var expectedProduct = new ProductoDeposito { IdDeposito = depositoId, IdProducto = productoId, Cantidad = 10 };

            var depositoService = new Mock<IDepositoService>();
            depositoService.Setup(s => s.GetDepositoProduct(depositoId, productoId)).ReturnsAsync(expectedProduct);

            // Act
            var result = await depositoService.Object.GetDepositoProduct(depositoId, productoId);

            // Assert
            Assert.Equal(expectedProduct, result);
        }
     
    }
}