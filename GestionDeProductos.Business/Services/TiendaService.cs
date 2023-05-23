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
            await _uow.Tienda.Insert(obj);
        }

        public async Task Update(Tienda obj)
        {
            await _uow.Tienda.Update(obj);
        }

        public async Task<IEnumerable<Tienda>> GetAll()
        {
            return await _uow.Tienda.GetAll();
        }

        public async Task<Tienda> GetOne(int guid)
        {
            return await _uow.Tienda.GetOne(guid);
        }

        public async Task Delete(int guid)
        {
            await _uow.Tienda.Delete(guid);
        }

        public async Task<ProductoTienda> GetTiendaProduct(int idTienda, int idProducto)
        {
            return await _uow.Tienda.GetTiendaProduct(idTienda, idProducto);
        }

        public async Task<IEnumerable<ProductoTienda>> GetAllTiendaProduct(int idTienda)
        {
            return await _uow.Tienda.GetAllTiendaProduct(idTienda);
        }

        public async Task InsertTiendaProduct(ProductoTienda product)
        {
            await _uow.Tienda.InsertTiendaProduct(product);
        }

        public async Task UpdateTiendaProduct(ProductoTienda product)
        {
            await _uow.Tienda.UpdateTiendaProduct(product);
        }

        public async Task DeleteTiendaProduct(int idTienda, int idProducto)
        {
            await _uow.Tienda.DeleteTiendaProduct(idTienda, idProducto);
        }
    }
}
