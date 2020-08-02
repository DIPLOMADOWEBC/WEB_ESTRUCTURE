using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface ISucursalUsuarioService : IEntityServiceBase<SucursalPersonalDTO>
    {

    }
    public class SucursalUsuarioService : IEntityServiceBase<SucursalPersonalDTO>, ISucursalUsuarioService
    {
        public void Create(SucursalPersonalDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SucursalPersonalDTO entity)
        {
            throw new NotImplementedException();
        }

        public SucursalPersonalDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(SucursalPersonalDTO entity)
        {
            throw new NotImplementedException();
        }

        public SucursalPersonalDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<SucursalPersonalDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            throw new NotImplementedException();
        }

        public List<SucursalPersonalDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            throw new NotImplementedException();
        }

        public void Update(SucursalPersonalDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
