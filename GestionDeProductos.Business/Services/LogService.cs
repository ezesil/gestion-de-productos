using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Business.Services
{
    public class LogService : ILogService
    {

        IUnitOfWork _uow;

        public LogService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<IEnumerable<Log>> GetAll()
        {
            return _uow.Log.SelectAll();
        }

        public async Task<Log> GetOne(int idLog)
        {
            return _uow.Log.SelectOne(new { idLog });
        }

        public async Task Insert(Log obj)
        {
            _uow.Log.Insert(obj);
        }

        public async Task Update(Log obj)
        {
            _uow.Log.Update(obj);
        }
    }
}
