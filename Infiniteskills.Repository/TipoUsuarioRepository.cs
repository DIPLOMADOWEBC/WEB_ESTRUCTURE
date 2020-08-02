using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface ITipoUsuarioRepository : IRepositoryBase<TipoUsuario>
    {

    }
    public class TipoUsuarioRepository : RepositoryBase<TipoUsuario>, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(ApplicationDbContext ApplicationDbContext) 
            : base(ApplicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<TipoUsuario, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<TipoUsuario>();
            return predicate;
        }

        public override List<TipoUsuario> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
