using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    
    public class BienServicioRepository : RepositoryBase<BienServicio>, IBienServicioRepository
    {
        public BienServicioRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] {
                "Categoria",
                "Proveedor",
                "Marca",
                "UnidadMedida"
            };
            return relatedEnties;
        }
        public override Expression<Func<BienServicio, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<BienServicio>();
            if (parameterList.ContainsKey("codigo"))
            {
                string value = Convert.ToString(parameterList["codigo"]);
                predicate = predicate.And(x => x.Codigo.Contains(value));
            }
            if (parameterList.ContainsKey("descripcion"))
            {
                string value = Convert.ToString(parameterList["descripcion"]);
                predicate = predicate.And(x => x.Descripcion.Contains(value));
            }

            if (parameterList.ContainsKey("marca"))
            {
                string value = Convert.ToString(parameterList["marca"]);
                predicate = predicate.And(x => x.Marca.Nombre.Contains(value));
            }

            if (parameterList.ContainsKey("proveedor"))
            {
                string value = Convert.ToString(parameterList["proveedor"]);
                predicate = predicate.And(x => x.Proveedor.RazonSocial.Contains(value));
            }

            if (parameterList.ContainsKey("categoriaId"))
            {
                int value = Convert.ToInt32(parameterList["categoriaId"]);
                predicate = predicate.And(x => x.CategoriaId == value);
            }

            return predicate;
        }

        public override List<BienServicio> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }

        public async Task<IEnumerable<BienServicio>> ListarBienServicio(string query)
        {
            var queryLinq = _applicationDbContext
               .BienServicio.Where(x => x.Descripcion.Contains(query) 
               || x.Codigo.Contains(query))
               .Take(10).ToListAsync();
            return await queryLinq;
        }
    }
}
