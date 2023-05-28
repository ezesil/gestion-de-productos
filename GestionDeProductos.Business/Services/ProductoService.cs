using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Business.Uow;
using GestionDeProductos.Domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Business.Services
{
    public class ProductoService : IGenericService<Producto>
    {
        IUnitOfWork _uow { get; }

        public ProductoService(IUnitOfWork uow) 
        { 
            _uow = uow;
        }

        public async Task Insert(Producto obj)
        {
            _uow.Producto.Open();
            _uow.Producto.Insert(obj);
            _uow.Producto.Commit();
        }

        public async Task Update(Producto obj)
        {
            _uow.Producto.Open();
            _uow.Producto.Update(obj);
            _uow.Producto.Commit();
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            _uow.Producto.Open();
            var result = _uow.Producto.SelectAll();
            return result;
        }

        public async Task<Producto> GetOne(int guid)
        {
            _uow.Producto.Open();
            var result = _uow.Producto.SelectOne(guid);
            return result;
        }

        public async Task Delete(int guid)
        {
            _uow.Producto.Open();
            _uow.Producto.Delete(guid);
            _uow.Producto.Commit();
        }
    }
}
