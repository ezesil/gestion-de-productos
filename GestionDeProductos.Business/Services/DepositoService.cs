using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Business.Uow;
using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GestionDeProductos.Business.Services
{
    public class DepositoService : IDepositoService
    {
        IUnitOfWork _uow { get; }

        public DepositoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Insert(Deposito obj)
        {
            await _uow.Deposito.Insert(obj);
        }

        public async Task Update(Deposito obj)
        {
            await _uow.Deposito.Update(obj);
        }

        public async Task<IEnumerable<Deposito>> GetAll()
        {
            return await _uow.Deposito.GetAll();
        }

        public async Task<Deposito> GetOne(int guid)
        {
            return await _uow.Deposito.GetOne(guid);
        }

        public async Task Delete(int guid)
        {
            await _uow.Deposito.Delete(guid);
        }

        public async Task<ProductoDeposito> GetDepositoProduct(int idDeposito, int idProducto)
        {
            return await _uow.Deposito.GetDepositoProduct(idDeposito, idProducto);
        }

        public async Task<IEnumerable<ProductoDeposito>> GetAllDepositoProduct(int idDeposito)
        {
            return await _uow.Deposito.GetAllDepositoProduct(idDeposito);
        }

        public async Task InsertDepositoProduct(ProductoDeposito product)
        {
            await _uow.Deposito.InsertDepositoProduct(product);
        }

        public async Task UpdateDepositoProduct(ProductoDeposito product)
        {
            await _uow.Deposito.UpdateDepositoProduct(product);
        }

        public async Task DeleteDepositoProduct(int idDeposito, int idProducto)
        {
            await _uow.Deposito.DeleteDepositoProduct(idDeposito, idProducto);
        }

        public void AgregarProducto(ProductoDeposito product)
        {
            using (var scope = new TransactionScope())
            {
                var currentProduct = _uow.Deposito.GetDepositoProduct(product.IdDeposito, product.IdProducto).Result;

                if (currentProduct == null)
                    _uow.Deposito.InsertDepositoProduct(product).Wait();
                else
                    _uow.Deposito.UpdateDepositoProduct(product).Wait();

                scope.Complete();
            }
        }

        public void TransferProductoADeposito(ProductoDeposito product, int IdDeposito, int cantidad)
        {
            if (product.IdDeposito == IdDeposito)
                return;

            using (var scope = new TransactionScope())
            {
                try
                {
                    var currentProduct = _uow.Deposito.GetDepositoProduct(product.IdDeposito, product.IdProducto).Result;
                    var destinationProduct = _uow.Deposito.GetDepositoProduct(IdDeposito, product.IdProducto).Result;

                    if (currentProduct == null || currentProduct.Cantidad < cantidad)
                        throw new Exception("No hay suficiente stock para transferir.");


                    // Tiene suficiente stock para transferir, modificamos y seguimos
                    currentProduct.Cantidad -= cantidad;
                    // Actualizamos
                    _uow.Deposito.UpdateDepositoProduct(currentProduct).Wait();


                    if (destinationProduct == null)
                    {
                        destinationProduct = new ProductoDeposito();
                        destinationProduct.IdDeposito = IdDeposito;
                        destinationProduct.IdProducto = product.IdProducto;
                        destinationProduct.Cantidad += cantidad;
                        _uow.Deposito.InsertDepositoProduct(destinationProduct).Wait();
                    }
                    else
                    {
                        destinationProduct.IdDeposito = IdDeposito;
                        destinationProduct.IdProducto = product.IdProducto;
                        destinationProduct.Cantidad += cantidad;
                        _uow.Deposito.UpdateDepositoProduct(destinationProduct).Wait();
                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void TransferProductoATienda(ProductoDeposito product, int idTienda, int cantidad)
        {
            try
            {

                using (var scope = new TransactionScope())
                {
                    try
                    {
                        var currentProduct = _uow.Deposito.GetDepositoProduct(product.IdDeposito, product.IdProducto).Result;
                        var destinationProduct = _uow.Tienda.GetTiendaProduct(idTienda, product.IdProducto).Result;

                        if (currentProduct == null || currentProduct.Cantidad < cantidad)
                            throw new Exception("No hay suficiente stock para transferir.");


                        // Tiene suficiente stock para transferir, modificamos y seguimos
                        currentProduct.Cantidad -= cantidad;
                        // Actualizamos
                        _uow.Deposito.UpdateDepositoProduct(currentProduct).Wait();


                        if (destinationProduct == null)
                        {
                            destinationProduct = new ProductoTienda();
                            destinationProduct.IdTienda = idTienda;
                            destinationProduct.IdProducto = product.IdProducto;
                            destinationProduct.Cantidad += cantidad;
                            _uow.Tienda.InsertTiendaProduct(destinationProduct).Wait();
                        }
                        else
                        {
                            destinationProduct.IdTienda = idTienda;
                            destinationProduct.IdProducto = product.IdProducto;
                            destinationProduct.Cantidad += cantidad;
                            _uow.Tienda.UpdateTiendaProduct(destinationProduct).Wait();
                        }

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
