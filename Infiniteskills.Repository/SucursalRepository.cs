using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Infiniteskills.Infra.Data;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface ISucursalRepository : IRepositoryBase<Sucursal>
    {

    }
    public class SucursalRepository : RepositoryBase<Sucursal>, ISucursalRepository
    {
        public SucursalRepository(ApplicationDbContext ApplicationDbContext) 
            : base(ApplicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] {
                "Empresa",
                "Distrito.Provincia.Departamento.Pais"
            };
            return relatedEnties;
        }
        public override Expression<Func<Sucursal, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Sucursal>();

            if (parameterList.ContainsKey("empresaId"))
            {
                int value = Convert.ToInt32(parameterList["empresaId"]);
                predicate = predicate.And(x => x.EmpresaId == value);
            }

            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombre.Contains(value));
            }
            if (parameterList.ContainsKey("empresa"))
            {
                string value = Convert.ToString(parameterList["empresa"]);
                predicate = predicate.And(x => x.Empresa.Nombre.Contains(value));
            }
            return predicate;
        }

        public override List<Sucursal> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
