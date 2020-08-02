using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {

    }
    public class CategoriaRepository:RepositoryBase<Categoria>,ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {

        }
        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<Categoria, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Categoria>();
            if (parameterList.ContainsKey("codigo"))
            {
                string value = Convert.ToString(parameterList["codigo"]);
                predicate = predicate.And(x => x.Codigo.Contains(value));
            }
            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombre.Contains(value));
            }
            return predicate;
        }

        public override List<Categoria> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(),BuildWhere(parameterList), orderBy);
        }
    }
}
