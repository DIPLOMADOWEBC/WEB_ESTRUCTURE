using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface IPeriodoEmpresaRepository : IRepositoryBase<PeriodoEmpresa>
    {
    }
    public class PeriodoEmpresaRepository : RepositoryBase<PeriodoEmpresa>, IPeriodoEmpresaRepository
    {
        public PeriodoEmpresaRepository(ApplicationDbContext ApplicationDbContext) 
            : base(ApplicationDbContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {"Periodo", "Sucursal"};
            return relatedEnties;
        }
        public override Expression<Func<PeriodoEmpresa, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<PeriodoEmpresa>();

            return predicate;
        }

        public override List<PeriodoEmpresa> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
    }
}
