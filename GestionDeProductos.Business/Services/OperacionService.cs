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
    public class OperacionService : IGenericService<Operacion>
    {
        IUnitOfWork _uow { get; }

        public OperacionService(IUnitOfWork uow) 
        { 
            _uow = uow;
        }

        public async Task Insert(Operacion obj)
        {
            _uow.Operacion.Insert(obj);
        }

        public async Task Update(Operacion obj)
        {
            _uow.Operacion.Update(obj);
        }

        public async Task<IEnumerable<Operacion>> GetAll()
        {
            return _uow.Operacion.SelectAll();
        }

        public async Task<Operacion> GetOne(int idOperacion)
        {
            return _uow.Operacion.SelectOne(new { idOperacion });
        }

        public async Task Delete(int idOperacion)
        {
            _uow.Operacion.Delete(new { idOperacion });
        }
    }
}
