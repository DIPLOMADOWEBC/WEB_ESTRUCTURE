
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Infiniteskills.Infra.Data;

namespace Infiniteskills.Repository
{
    public interface IRolRepository : IRepositoryBase<Rol>
    {

    }
    public class RolRepository : RepositoryBase<Rol>, IRolRepository
    {
        public RolRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
      {

         string[] relatedEnties = new string[] {
            "OrigenRegistro"
         };
         return relatedEnties;
      }
      public override Expression<Func<Rol, bool>> BuildWhere(Dictionary<string, object> parameterList)
      {
         var predicate = PredicateBuilder.True<Rol>();

         if (parameterList.ContainsKey("rolId"))
         {
            int value = Convert.ToInt32(parameterList["rolId"]);
            predicate = predicate.And(x => x.RolId == value);
         }
         if (parameterList.ContainsKey("nombre"))
         {
            string value = Convert.ToString(parameterList["nombre"]);
            predicate = predicate.And(x => x.Nombre.Contains(value));
         }
         if (parameterList.ContainsKey("rol"))
         {
            string value = Convert.ToString(parameterList["rol"]);
            predicate = predicate.And(x => x.Codigo == value);
         }

         if (parameterList.ContainsKey("estado"))
         {
            string value = Convert.ToString(parameterList["estado"]);
            predicate = predicate.And(x => x.Estado == value);
         }
        
         
         return predicate;
      }
      public override List<Rol> SearchFor(Dictionary<string, object> parameterList, int pageSize, string orderBy)
      {
         return this.ExecuteSearch(this.IncludeEntity(), this.BuildWhere(parameterList), pageSize, orderBy);
      }
    
   }
}
