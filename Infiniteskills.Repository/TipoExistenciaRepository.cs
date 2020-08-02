using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using Infiniteskills.Infra.Data;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface ITipoExistenciaRepository : IRepositoryBase<TipoExistencia>
    {

    }
    public class TipoExistenciaRepository : RepositoryBase<TipoExistencia>, ITipoExistenciaRepository
    {
        public TipoExistenciaRepository(ApplicationDbContext ApplicationDbContext)
            : base(ApplicationDbContext)
        {
        }

        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<TipoExistencia, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<TipoExistencia>();
            return predicate;
        }

        public override List<TipoExistencia> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
