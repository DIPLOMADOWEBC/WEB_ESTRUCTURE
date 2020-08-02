using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Repository;
using Infiniteskills.Infra.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Infiniteskills.Repository
{
    public interface IDocumentoComercialRepository : IRepositoryBase<DocumentoComercial>
    {

    }
    public class DocumentoComercialRepository : RepositoryBase<DocumentoComercial>, IDocumentoComercialRepository
    {
        public DocumentoComercialRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<DocumentoComercial, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<DocumentoComercial>();
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

        public override List<DocumentoComercial> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
