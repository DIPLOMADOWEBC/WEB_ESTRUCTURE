using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using NLog;
using System;
using System.Collections.Generic;


namespace Infiniteskills.Service
{
    public interface IRolService : IEntityServiceBase<RolDTO>
    {

    }
    public class RolService : IEntityServiceBase<RolDTO>, IRolService
    {
      private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Create(RolDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RolDTO entity)
        {
            throw new NotImplementedException();
        }

        public RolDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(RolDTO entity)
        {
            throw new NotImplementedException();
        }

        public RolDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<RolDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            throw new NotImplementedException();
        }

        public List<RolDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            throw new NotImplementedException();
        }

        public void Update(RolDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
