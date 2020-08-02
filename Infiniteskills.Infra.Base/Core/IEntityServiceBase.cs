using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Infra.Base
{
    [ServiceContract()]
    public  interface IEntityServiceBase<TDTOEntity>
    {
        [OperationContract()]
        string[] Insert(TDTOEntity entity);

        [OperationContract()]
        void Create(TDTOEntity entity);

        [OperationContract()]
        void Update(TDTOEntity entity);

        [OperationContract()]
        void Delete(TDTOEntity entity);

        [OperationContract()]
        TDTOEntity GetById(int id);

        [OperationContract()]
        TDTOEntity SearchFor(Dictionary<string, object> parameterList);

        [OperationContract()]
        List<TDTOEntity> SearchFor(Dictionary<string, object> parametersList, string orderBy);

        [OperationContract()]
        List<TDTOEntity> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy);
    }
}
