using System;
using System.Collections.Generic;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using NLog;


namespace Infiniteskills.Service
{
    public interface IRolMenuService : IEntityServiceBase<RolMenuDTO>
    {

    }

    public class RolMenuService :IEntityServiceBase<RolMenuDTO>, IRolMenuService
    {
      private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Create(RolMenuDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RolMenuDTO entity)
        {
            throw new NotImplementedException();
        }

        public RolMenuDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(RolMenuDTO entity)
        {
            throw new NotImplementedException();
        }

        public RolMenuDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<RolMenuDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            throw new NotImplementedException();
        }

        public List<RolMenuDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            throw new NotImplementedException();
        }

        public void Update(RolMenuDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}