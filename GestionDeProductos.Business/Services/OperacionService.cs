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
            await _uow.Operacion.Insert(obj);
        }

        public async Task Update(Operacion obj)
        {
            await _uow.Operacion.Update(obj);
        }

        public async Task<IEnumerable<Operacion>> GetAll()
        {
            return await _uow.Operacion.GetAll();
        }

        public async Task<Operacion> GetOne(int guid)
        {
            return await _uow.Operacion.GetOne(guid);
        }

        public async Task Delete(int guid)
        {
            await _uow.Operacion.Delete(guid);
        }
    }
}
