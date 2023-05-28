using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Business.Uow;
using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Business.Services
{
    public class TiendaService : ITiendaService
    {
        IUnitOfWork _uow { get; }

        public TiendaService(IUnitOfWork uow) 
        { 
            _uow = uow;
        }

        public async Task Insert(Tienda obj)
        {
            _uow.Tienda.Insert(obj);
        }

        public async Task Update(Tienda obj)
        {
            _uow.Tienda.Update(obj);
        }

        public async Task<IEnumerable<Tienda>> GetAll()
        {
            return _uow.Tienda.SelectAll();
        }

        public async Task<Tienda> GetOne(int idTienda)
        {
            return _uow.Tienda.SelectOne(new { idTienda });
        }

        public async Task Delete(int idTienda)
        {
            _uow.Tienda.Delete(new { idTienda });
        }

        public async Task<ProductoTienda> GetTiendaProduct(int idTienda, int idProducto)
        {
            return _uow.ProductoTienda.SelectOne(new { idTienda, idProducto });
        }

        public async Task<IEnumerable<ProductoTienda>> GetAllTiendaProduct(int idTienda)
        {
            return _uow.ProductoTienda.SelectAll(new { idTienda });
        }

        public async Task InsertTiendaProduct(ProductoTienda product)
        {
            _uow.ProductoTienda.Insert(product);
        }

        public async Task UpdateTiendaProduct(ProductoTienda product)
        {
            _uow.ProductoTienda.Update(product);
        }

        public async Task DeleteTiendaProduct(int idTienda, int idProducto)
        {
            _uow.ProductoTienda.Delete(new { idTienda, idProducto });
        }
    }
}
