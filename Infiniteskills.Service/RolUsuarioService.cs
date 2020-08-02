using System;
using System.Collections.Generic;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using NLog;

namespace Infiniteskills.Service
{
    public interface IRolUsuarioService
    {

    }
    public class RolUsuarioService : IEntityServiceBase<RolUsuarioDTO>, IRolUsuarioService
    {
      private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Create(RolUsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RolUsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public RolUsuarioDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(RolUsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public RolUsuarioDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<RolUsuarioDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            throw new NotImplementedException();
        }

        public List<RolUsuarioDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            throw new NotImplementedException();
        }

        public void Update(RolUsuarioDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
