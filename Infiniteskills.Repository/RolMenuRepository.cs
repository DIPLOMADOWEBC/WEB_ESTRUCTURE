
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Infiniteskills.Infra.Data;

namespace Infiniteskills.Repository
{
    public interface IRolMenuRepository : IRepositoryBase<RolMenu>
    {

    }
    public class RolMenuRepository : RepositoryBase<RolMenu>, IRolMenuRepository
    {
        public RolMenuRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
      {

         string[] relatedEnties = new string[] {
            "Rol",
            "Menu"
         };
         return relatedEnties;
      }
      public override Expression<Func<RolMenu, bool>> BuildWhere(Dictionary<string, object> parameterList)
      {
         var predicate = PredicateBuilder.True<RolMenu>();

         if (parameterList.ContainsKey("rolMenuId"))
         {
            int value = Convert.ToInt32(parameterList["rolMenuId"]);
            predicate = predicate.And(x => x.RolMenuId == value);
         }
         if (parameterList.ContainsKey("rolId"))
         {
            int value = Convert.ToInt32(parameterList["rolId"]);
            predicate = predicate.And(x => x.RolId == value);
         }
         if (parameterList.ContainsKey("menuId"))
         {
            int value = Convert.ToInt32(parameterList["menuId"]);
            predicate = predicate.And(x => x.MenuId == value);
         }
         if (parameterList.ContainsKey("rolList"))
         {
            List<string> valueList = (List<string>)(parameterList["rolList"]);
            predicate = predicate.And(x => valueList.Contains(x.Rol.Codigo));
         }
         if (parameterList.ContainsKey("lectura"))
         {
            string value = Convert.ToString(parameterList["lectura"]);
            predicate = predicate.And(x => x.Lectura == value);
         }
         return predicate;
      }
      public override List<RolMenu> SearchFor(Dictionary<string, object> parameterList, int pageSize, string orderBy)
      {
         return this.ExecuteSearch(this.IncludeEntity(), this.BuildWhere(parameterList), pageSize, orderBy);
      }
   }
}
