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
        IGenericService<Operacion> _operacionService { get; }

        public DepositoService(IUnitOfWork uow, IGenericService<Operacion> operacionService)
        {
            _uow = uow;
            _operacionService = operacionService;
        }

        public async Task Insert(Deposito obj)
        {
            _uow.Deposito.Open();
            _uow.Deposito.Insert(obj);
            _uow.Deposito.Commit();
        }

        public async Task Update(Deposito obj)
        {
            _uow.Deposito.Open();
            _uow.Deposito.Update(obj);
            _uow.Deposito.Commit();
        }

        public async Task<IEnumerable<Deposito>> GetAll()
        {
            return _uow.Deposito.SelectAll();
        }

        public async Task<Deposito> GetOne(int idDeposito)
        {
            return _uow.Deposito.SelectOne(new { idDeposito });
        }

        public async Task Delete(int idDeposito)
        {
            _uow.Deposito.Delete(new { idDeposito });
        }

        public async Task<ProductoDeposito> GetDepositoProduct(int idDeposito, int idProducto)
        {
            return _uow.ProductoDeposito.SelectOne(new { idDeposito, idProducto });
        }

        public async Task<IEnumerable<ProductoDeposito>> GetAllDepositoProduct(int idDeposito)
        {
            return _uow.ProductoDeposito.SelectAll(new { idDeposito });
        }

        public async Task InsertDepositoProduct(ProductoDeposito product)
        {
            _uow.ProductoDeposito.Insert(product);
        }

        public async Task UpdateDepositoProduct(ProductoDeposito product)
        {
            _uow.ProductoDeposito.Update(product);
        }

        public async Task DeleteDepositoProduct(int idDeposito, int idProducto)
        {
            _uow.ProductoDeposito.Delete(new { idDeposito, idProducto });
        }

        public void AgregarProducto(ProductoDeposito product)
        {
            using (var scope = new TransactionScope())
            {
                var currentProduct = _uow.ProductoDeposito.SelectOne(new { product.IdDeposito, product.IdProducto });

                if (currentProduct == null)
                    _uow.ProductoDeposito.Insert(product);
                else
                {
                    currentProduct.Cantidad += product.Cantidad;
                    _uow.ProductoDeposito.Update(currentProduct);
                }

                scope.Complete();
            }
        }

        public void TransferProductoADeposito(ProductoDeposito product, int IdDeposito, int cantidad)
        {
            if (product.IdDeposito == IdDeposito)
                return;

            bool success = false;

            using (var scope = new TransactionScope())
            {
                try
                {
                    var currentProduct = _uow.ProductoDeposito.SelectOne(new { product.IdDeposito, product.IdProducto });
                    var destinationProduct = _uow.ProductoDeposito.SelectOne(new { IdDeposito, product.IdProducto });

                    if (currentProduct == null || currentProduct.Cantidad < cantidad)
                        throw new Exception("No hay suficiente stock para transferir.");


                    // Tiene suficiente stock para transferir, modificamos y seguimos
                    currentProduct.Cantidad -= cantidad;
                    // Actualizamos
                    _uow.ProductoDeposito.Update(currentProduct);


                    if (destinationProduct == null)
                    {
                        destinationProduct = new ProductoDeposito();
                        destinationProduct.IdDeposito = IdDeposito;
                        destinationProduct.IdProducto = product.IdProducto;
                        destinationProduct.Cantidad += cantidad;
                        _uow.ProductoDeposito.Insert(destinationProduct);
                    }
                    else
                    {
                        destinationProduct.IdDeposito = IdDeposito;
                        destinationProduct.IdProducto = product.IdProducto;
                        destinationProduct.Cantidad += cantidad;
                        _uow.ProductoDeposito.Update(destinationProduct);
                    }


                    scope.Complete();
                    success = true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            if (success)
            {
                _uow.Operacion.Insert(new Operacion()
                {
                    Origen = product.IdProducto,
                    Destino = IdDeposito,
                    Fecha = DateTime.Now,
                    Usuario = "",
                    EsDeposito = true,
                });
            }
        }

        public void TransferProductoATienda(ProductoDeposito product, int idTienda, int cantidad)
        {
            bool success = false;
            using (var scope = new TransactionScope())
            {
                try
                {
                    var currentProduct = _uow.ProductoDeposito.SelectOne(new { product.IdDeposito, product.IdProducto });
                    var destinationProduct = _uow.ProductoTienda.SelectOne(new { idTienda, product.IdProducto });

                    if (currentProduct == null || currentProduct.Cantidad < cantidad)
                        throw new Exception("No hay suficiente stock para transferir.");


                    // Tiene suficiente stock para transferir, modificamos y seguimos
                    currentProduct.Cantidad -= cantidad;
                    // Actualizamos
                    _uow.ProductoDeposito.Update(currentProduct);


                    if (destinationProduct == null)
                    {
                        destinationProduct = new ProductoTienda();
                        destinationProduct.IdTienda = idTienda;
                        destinationProduct.IdProducto = product.IdProducto;
                        destinationProduct.Cantidad += cantidad;
                        _uow.ProductoTienda.Insert(destinationProduct);
                    }
                    else
                    {
                        destinationProduct.IdTienda = idTienda;
                        destinationProduct.IdProducto = product.IdProducto;
                        destinationProduct.Cantidad += cantidad;
                        _uow.ProductoTienda.Update(destinationProduct);
                    }

                    scope.Complete();

                    success = true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            if (success)
            {
                _uow.Operacion.Insert(new Operacion()
                {
                    Origen = product.IdProducto,
                    Destino = idTienda,
                    Fecha = DateTime.Now,
                    Usuario = "",
                    EsDeposito = false,
                });
            }
        }
    }
}
