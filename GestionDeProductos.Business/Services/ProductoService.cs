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
            await _uow.Producto.Insert(obj);
        }

        public async Task Update(Producto obj)
        {
            await _uow.Producto.Update(obj);
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _uow.Producto.GetAll();
        }

        public async Task<Producto> GetOne(int guid)
        {
            return await _uow.Producto.GetOne(guid);
        }

        public async Task Delete(int guid)
        {
            await _uow.Producto.Delete(guid);
        }
    }
}
