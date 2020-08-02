using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface IDireccionRepository: IRepositoryBase<DireccionProveedor>
    {

    }
    public class DireccionRepository : RepositoryBase<DireccionProveedor>, IDireccionRepository
    {
        public DireccionRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] {
                "Distrito.Provincia.Departamento.Pais"
            };
            return relatedEnties;
        }

        public override List<DireccionProveedor> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
           
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
        public override Expression<Func<DireccionProveedor, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<DireccionProveedor>();
            if (parameterList.ContainsKey("proveedorId"))
            {
                int value = Convert.ToInt32(parameterList["proveedorId"]);
                predicate = predicate.And(x => x.ProveedorId == value);
            }

            return predicate;
        }
    }
}
