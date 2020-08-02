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
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {

    }
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<Empresa, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Empresa>();
            if (parameterList.ContainsKey("nombre"))
            {
                string value = Convert.ToString(parameterList["nombre"]);
                predicate = predicate.And(x => x.Nombre.Contains(value));
            }
            if (parameterList.ContainsKey("numeroRuc"))
            {
                string value = Convert.ToString(parameterList["numeroRuc"]);
                predicate = predicate.And(x => x.NumeroRuc.Contains(value));
            }
            if (parameterList.ContainsKey("telefono"))
            {
                string value = Convert.ToString(parameterList["telefono"]);
                predicate = predicate.And(x => x.Telefono.Contains(value));
            }
            return predicate;
        }

        public override List<Empresa> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
