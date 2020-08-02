using System;
using System.Collections.Generic;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System.Linq;
using System.Data.Entity.Validation;
using System.Linq.Expressions;
using Infiniteskills.Infra.Core;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    public interface IPeriodoCorrelativoRepository : IRepositoryBase<PeriodoCorrelativo>
    {
        string ObtenerCorrelativo(Dictionary<string, object> parameterList);
        string ObtenerCodigoProducto(Dictionary<string, object> parameterList);
    }
    public class PeriodoCorrelativoRepository : RepositoryBase<PeriodoCorrelativo>, IPeriodoCorrelativoRepository
    {
        public PeriodoCorrelativoRepository(ApplicationDbContext ApplicationDbContext)
            : base(ApplicationDbContext)
        {
        }

        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] {
                    "Tabla",
                    "PeriodoEmpresa.Periodo",
                    "PeriodoEmpresa.Sucursal",
            };
            return relatedEnties;
        }
        public override Expression<Func<PeriodoCorrelativo, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<PeriodoCorrelativo>();
            return predicate;
        }
        public override List<PeriodoCorrelativo> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }

        public string ObtenerCorrelativo(Dictionary<string, object> parameterList)
        {
            using (var transaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {


                    string codigoTabla = parameterList["tabla"].ToString();
                    PeriodoCorrelativo periodoCorrelativo = _applicationDbContext.PeriodoCorrelativo
                        .Include("Tabla").Where(x => x.Tabla.Codigo == codigoTabla).FirstOrDefault();

                    periodoCorrelativo.Correlativo += 1;
                    _applicationDbContext.SaveChanges();
                    transaction.Commit();

                    return periodoCorrelativo.Correlativo.ToString(periodoCorrelativo.Tabla.Formato).Trim();


                }
                catch (DbEntityValidationException ex)
                {
                    transaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }
            }

        }

        public string ObtenerCodigoProducto(Dictionary<string, object> parameterList)
        {
            using (var transaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {


                    string codigoTabla = parameterList["tabla"].ToString();
                    PeriodoCorrelativo periodoCorrelativo = _applicationDbContext.PeriodoCorrelativo
                        .Include("Tabla").Where(x => x.Tabla.Codigo == codigoTabla).FirstOrDefault();

                    periodoCorrelativo.Correlativo += 1;
                    _applicationDbContext.SaveChanges();
                    transaction.Commit();

                    return periodoCorrelativo.Correlativo.ToString(periodoCorrelativo.Tabla.Formato).Trim();


                }
                catch (DbEntityValidationException ex)
                {
                    transaction.Rollback();
                    string entityValidationError = GetEntityValidationErrorMessage(ex);
                    throw new Exception(entityValidationError);
                }
            }
        }
    }
}
